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
import { MenuItem, SharedModule } from 'primeng/api';
import { MenubarModule } from 'primeng/menubar';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.less'],
  providers: [MenubarModule, SharedModule]
})
export class MenuComponent implements OnInit, OnDestroy {
  @Input() title: string = "Site Title";

  public items: MenuItem[] = [];
  public userItems: MenuItem[] = [];
  public userButtonText: string = "";

  model: any = {};
  private itemChecked: string[] = [];

  private authSubscribe: Subscription;

  constructor(private menu: MenuService, public auth: AuthService, private route: Router) {
    this.authSubscribe = auth.currentUser$.subscribe(user => {
      if (user.isAuthenticated) {
        this.userButtonText = `${user.firstName} ${user.lastName}`;
        this.menu.currentMenu$.pipe(take(1)).subscribe((menuItems: MenuItemEntity[]) => {
          // Clear the menu data structures
          this.items = [];
          this.itemChecked = [];
          this.userItems = [];
          // Convert menu items to primeng menu items
          for (let item of menuItems) {
            if (this.itemChecked.indexOf(item.guid) < 0) {
              // Create menu item and add it to the data array
              this.items.push(this.addMenuItem(item));
            }
          }

          // Add general user commands
          this.userItems.push({
            label: 'Account',
            icon: 'fa fa-user',
            routerLink: '/auth/whoami'
          });
          this.userItems.push({
            label: 'Reset Password',
            icon: 'fa fa-key',
            routerLink: '/auth/resetpw'
          });
          this.userItems.push({
            label: 'Logout',
            icon: 'pi pi-sign-out',
            routerLink: '/auth/logout'
          });

        });
      } else {
        // Make sure the login menu is cleared for non authenticated users
        this.items = [];
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

    this.itemChecked.push(item.guid);

    // Check if parent is defined
    if (parent !== undefined) {
      // Check if parent items list is defined, if not create it
      if (parent.items === undefined) {
        parent.items = [];
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
