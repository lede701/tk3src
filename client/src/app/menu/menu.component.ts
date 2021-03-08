import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { take } from 'rxjs/operators';

import { MenuItemEntity } from '../entities/menuItemEntity';
import { environment } from '../../environments/environment';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { NgForm } from '@angular/forms';
import { MenuService } from './menu.service';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.less']
})
export class MenuComponent implements OnInit, OnDestroy {
  @Input() title: string = "Site Title";

  public menuItems: MenuItemEntity[] = [];
  public items: MenuItem[] = [];
  model: any = {};

  private authSubscribe: Subscription;

  constructor(private menuService: MenuService, public auth: AuthService, private route: Router) {
    this.authSubscribe = this.auth.currentUser$.subscribe(user => {
      this.menuItems = [];
      if (user.isAuthenticated) {
          menuService.currentMenu$.pipe(take(1)).subscribe(results => {
          this.menuItems = results;
        });
      }
    });
  }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    this.authSubscribe.unsubscribe();
  }

  login(loginForm: NgForm) {
    this.auth.login(this.model.userName, this.model.password).pipe(take(1)).subscribe(results => {
      loginForm.reset();
      this.route.navigate(['/']);
    });
  }

  logout() {
    this.auth.logout();
    this.menuService.currentMenu$.pipe(take(1)).subscribe(results => {
      this.menuItems = [];
    });
    this.route.navigate(['/']);
  }

  getName(): string {
    return this.auth.getName();
  }

  private addMenuItem(item: MenuItemEntity, parent?: MenuItem): MenuItem {
    // Create the PrimeNG menu item interface object
    let mItem: MenuItem = {
      label: item.name,
      routerLink: '/' + item.route,
      id: item.guid,
    };

    // Check if parent is defined
    if (parent !== undefined) {
      // Check if parent items list is defined, if not create it
      if (parent.items === undefined) {
        parent.items = [];
        parent.items.push({
          label: parent.label,
          routerLink: parent.routerLink
        });
        parent.routerLink = '';
      }
      // Add item to list of parent
      parent.items.push(mItem);
    }

    // Check if we need to recursivaly add items from children records
    if (item.children) {
      // Process each child in the children array
      for (let child of item.children) {
        this.addMenuItem(child, mItem);
      }
    }

    return mItem;
  }
}
