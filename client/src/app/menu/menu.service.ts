import { HttpClient } from '@angular/common/http';
import { Injectable, OnDestroy } from '@angular/core';
import { ReplaySubject, Subscription } from 'rxjs';
import { take } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { MenuItemEntity } from '../entities/menuItemEntity';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class MenuService implements OnDestroy {

  private _baseUri = environment.apiUrl;

  private _currentMenu = new ReplaySubject<MenuItemEntity[]>(1);
  public currentMenu$ = this._currentMenu.asObservable();

  private authSubscription: Subscription;

  constructor(private http: HttpClient, auth: AuthService) {
    this.authSubscription = auth.currentUser$.subscribe(user => {
      this.http.get<MenuItemEntity[]>(this._baseUri + '/Menu').pipe(take(1)).subscribe(results => {
        let menu = [...results, new MenuItemEntity('Logout', 'auth/logout', '')];
        this._currentMenu.next(menu);
      });
    });
  }

  ngOnDestroy(): void {
    if (this.authSubscription) {
      this.authSubscription.unsubscribe();
    }
  }
}
