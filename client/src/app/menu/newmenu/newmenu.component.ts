import { Component, OnInit } from '@angular/core';
import { MenubarModule } from 'primeng/menubar';
import { MenuItem } from 'primeng/api';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-newmenu',
  templateUrl: './newmenu.component.html',
  styleUrls: ['./newmenu.component.less'],
  providers: [MenubarModule]
})
export class NewmenuComponent implements OnInit {
  public title: string = "Site Name";

  items: MenuItem[] = [];

  constructor(public auth: AuthService) { }

  ngOnInit(): void {
    this.items.push({
      label: 'Home',
      routerLink: '/'
    });
  }

  getName() {
    return this.auth.getName();
  }

}
