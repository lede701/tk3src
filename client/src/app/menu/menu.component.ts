import { Component, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take } from 'rxjs/operators';

import { MenuItemEntity } from '../entities/menuItemEntity';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.less']
})
export class MenuComponent implements OnInit {
  @Input() title: string = "Site Title";
  public menuItems: MenuItemEntity[] = [];
  private _menuSub: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {

    let url = environment.apiUrl + '/Menu';
    // Creating a memory leak that needs to be fixed!
    
    this._menuSub = this.http.get<MenuItemEntity[]>(url).pipe(take(1))
    
  }

  menuSetup() {
    /*
    this.menuItems = [new MenuItemEntity('/', 'Home', 'is-active', true)];

    if (this.auth.getIsAuthenticated()) {
      this.menuItems.push(
        new MenuModel('/day', 'Timesheets', 'is-active', false, [
          new MenuModel('/timesheet', 'Sheet View', 'is-active', false)
        ]));
      this.menuItems.push(new MenuModel('/leave', 'Leave', 'is-active', false));
      if (this.auth.getUserName() === 'lede@ncjfcj.org') {
        this.menuItems.push(new MenuModel('/admin', 'Admin', 'is-active', false, [
          new MenuModel('/menu', 'Menu Admin', 'is-active', false)
        ]));
      }
      this.menuItems.push(new MenuModel(['auth', 'logout'], 'Logout', 'is-active', false));
    } else {
      this.menuItems.push(new MenuModel(['auth', 'login'], 'Login', 'is-active', false));
    }*/

  }


}
