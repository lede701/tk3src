import { Component, OnInit } from '@angular/core';
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
  public menuItems: MenuItemEntity[] = [];
  private _menuSub: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    let url = environment.apiUrl + '/Menu';
    // Creating a memory leak that needs to be fixed!
    this._menuSub = this.http.get<MenuItemEntity[]>(url).pipe(take(1)).subscribe(menu => {
      this.menuItems = menu;
    });
  }

}
