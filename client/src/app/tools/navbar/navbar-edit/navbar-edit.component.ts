import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { MenuService } from '../../../menu/menu.service';

@Component({
  selector: 'app-navbar-edit',
  templateUrl: './navbar-edit.component.html',
  styleUrls: ['./navbar-edit.component.less']
})
export class NavbarEditComponent implements OnInit {

  constructor(private active: ActivatedRoute, private route: Router, private menu: MenuService) { }

  ngOnInit(): void {
    let guid = this.active.snapshot.params?.guid;
    if (guid != 'new') {
      this.menu.getMenuItem(guid).pipe(take(1)).subscribe(results => {
        console.log(results);
      });
    }
  }

}
