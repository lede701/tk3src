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

  public tempItems: MenuItemEntity[] = [];

  constructor(private http: HttpClient, public auth: AuthService) { }

  ngOnInit(): void {
    let url = environment.apiUrl + '/Menu';
    // Creating a memory leak that needs to be fixed!
    this.http.get<MenuItemEntity[]>(url).pipe(take(1)).subscribe(menu => {
      this.menuItems = menu;
      if (this.auth.getIsAuthenticated()) {
        this.menuItems.push(new MenuItemEntity('Logout', 'auth/logout', ''));
      }
    });
  }

  login() {
    this.auth.login(this.model.userName, this.model.password).pipe(take(1)).subscribe(results => {

      console.log(results);
    })
  }

  logout() {
    this.auth.logout();
  }
}
