import { Component, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take } from 'rxjs/operators';

import { MenuItemEntity } from '../entities/menuItemEntity';
import { environment } from '../../environments/environment';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.less']
})
export class MenuComponent implements OnInit {
  @Input() title: string = "Site Title";
  public menuItems: MenuItemEntity[] = [];
  model: any = {};

  constructor(private http: HttpClient, public authService: AuthService) { }

  ngOnInit(): void {

    let url = environment.apiUrl + '/Menu';
    // Creating a memory leak that needs to be fixed!
    this.http.get<MenuItemEntity[]>(url).pipe(take(1)).subscribe(menu => {
      this.menuItems = menu;
    });
  }

  login() {
    this.authService.login(this.model.userName, this.model.password).pipe(take(1)).subscribe(results => {

      //console.log(results);
    })
  }

  logout() {
    this.authService.logout();
  }

}
