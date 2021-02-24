import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { UserEntity } from '../entities/userEntity';
import { take } from 'rxjs/operators';



@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let currentUser: UserEntity = new UserEntity();
    

    this.authService.currentUser$.pipe(take(1)).subscribe(user => currentUser = user);

    if (currentUser.username != '') {
      console.log('Adding JWT');
      req = req.clone({
        setHeaders: {
          Autherization: `Bearer ${currentUser.token}`
        }
      });
      console.log(currentUser);
    }

    return next.handle(req);
  }

}
