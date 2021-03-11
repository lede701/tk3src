import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { MenuItemEntity } from '../../entities/menuItemEntity';
import { MenuService } from '../../menu/menu.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.less']
})
export class NavbarComponent implements OnInit {
  menuList: MenuItemEntity[] = [];

  constructor(private menu: MenuService, private route: Router, private cdr: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.menu.currentMenu$.pipe(take(1)).subscribe(results => {
      let trackItem: string[] = [];
      this.menuList = [];
      for (let item of results) {
        trackItem = this.addMenuItemToList(item, trackItem);
      }
    });
  }

  onEditMenu(menu: MenuItemEntity) {
    this.route.navigate(['/', 'tools', 'navbar', menu.guid]);
  }

  onDeleteMenu(menu: MenuItemEntity) {
    console.log(menu);
  }

  onNewMenuItem() {
    this.route.navigate(['/', 'tools', 'navbar', 'new']);
  }

  private addMenuItemToList(item: MenuItemEntity, track: string[]): string[] {
    if (track.indexOf(item.guid) < 0) {
      track.push(item.guid);
      this.menuList.push(item);
    }
    if (item.children?.length > 0) {
      for (let child of item.children) {
        track.push(child.guid);
      }
    }
    return track;
  }
}
