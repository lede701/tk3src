import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take } from 'rxjs/operators';

import { MenuItemEntity } from '../entities/menuItemEntity';
import { environment } from '../../environments/environment';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.less']
})
export class MenuComponent implements OnInit, OnDestroy {
  @Input() title: string = "Site Title";
  public menuItems: MenuItemEntity[] = [];
  model: any = {};

  private authSubscribe: any;

  constructor(private http: HttpClient, public auth: AuthService, private route: Router) { }

  ngOnInit(): void {
    this.setupMenu();
    this.authSubscribe = this.auth.currentUser$.subscribe(user => {
      this.setupMenu();
    });
  }

  ngOnDestroy(): void {

  }

  setupMenu() {
    let url = environment.apiUrl + '/Menu';
    // Creating a memory leak that needs to be fixed!
    this.http.get<MenuItemEntity[]>(url).pipe(take(1)).subscribe(menu => {
      this.menuItems = menu;
      if (this.auth.getIsAuthenticated()) {
        this.menuItems.push(new MenuItemEntity('Logout', 'auth/logout', ''));
        this.menuItems.push(new MenuItemEntity('Who Am I', 'auth/whoami', ''));
      }
    });
  }

  login() {
    this.auth.login(this.model.userName, this.model.password).pipe(take(1)).subscribe(results => {
      this.route.navigate(['/']);
    });
  }

  logout() {
    this.auth.logout();
  }
}
