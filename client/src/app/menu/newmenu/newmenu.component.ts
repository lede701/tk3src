import { Component, OnInit } from '@angular/core';
import { MenubarModule } from 'primeng/menubar';
import { MenuItem } from 'primeng/api';
import { AuthService } from '../../services/auth.service';
import { MenuService } from '../menu.service';
import { take } from 'rxjs/operators';
import { MenuItemEntity } from '../../entities/menuItemEntity';

@Component({
  selector: 'app-newmenu',
  templateUrl: './newmenu.component.html',
  styleUrls: ['./newmenu.component.less'],
  providers: [MenubarModule]
})
export class NewmenuComponent implements OnInit {
  public title: string = "Site Name";

  items: MenuItem[] = [];

  constructor(public auth: AuthService, private menu: MenuService) {
    this.menu.currentMenu$.pipe(take(1)).subscribe((menuItems: MenuItemEntity[]) => {
      this.items = [];
      // Convert menu items to primeng menu items
      for (let item of menuItems) {
        this.items.push(this.addMenuItem(item));
      }
    });
  }

  ngOnInit(): void { }

  getName() {
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
