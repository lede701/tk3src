import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';

import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.less']
})
export class AuthComponent implements OnInit {

  public task: string = '';

  constructor(private activeRoute: ActivatedRoute, private router: Router, private auth: AuthService) { }

  ngOnInit(): void {
    this.task = this.activeRoute.snapshot.params.task;
    if (this.task == 'logout') {
      this.auth.logout();
      this.router.navigate(['/']);
    }
    if (this.task == 'whoami') {
      this.WhoAmI();
    }
  }

  WhoAmI() {
    this.auth.WhoAmI().pipe(take(1)).subscribe(results => {
      console.log(results);
    });
  }
}
