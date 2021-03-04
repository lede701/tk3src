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
  public data: any;
  public showTask: boolean = true;
  public isReady: boolean = false;

  constructor(private activeRoute: ActivatedRoute, private router: Router, private auth: AuthService) { }

  ngOnInit(): void {
    this.task = this.activeRoute.snapshot.params.task;
    if (this.task == 'logout') {
      this.auth.logout();
      this.router.navigate(['/']);
    }
    if (this.task == 'whoami') {
      this.WhoAmI();
      this.showTask = false;
    }
    // Check if we are to show the create form
    if (this.task == 'create') {
      this.showTask = false;
    }
  }

  WhoAmI() {
    this.auth.WhoAmI().pipe(take(1)).subscribe(results => {
      this.data = results;
      this.isReady = true;
      console.log(results);
    });
  }
}
