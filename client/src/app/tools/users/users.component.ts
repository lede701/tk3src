import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { IUserEntity } from '../../entities/iuserentity';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.less']
})
export class UsersComponent implements OnInit {
  userList: IUserEntity[] = [];

  private _userListSubscription: Subscription;

  public searchForm: FormGroup;
  public search: string = '';

  constructor(private auth: AuthService, private route: Router, private fb: FormBuilder) {
    this._userListSubscription = this.auth.getListOfUsers().subscribe(results => {
      this.userList = results;
    });

    // Setup search form
    this.searchForm = this.fb.group({
      search: [this.search, [Validators.required]]
    });
  }

  ngOnInit(): void {
  }

  isNotCurrentUser(user: IUserEntity) {
    return user.userName != 'lede';
  }

  onUserEdit(user: IUserEntity) {
    this.route.navigate(['/', 'tools', 'users', user.guid]);
  }

  onUserDelete(user: IUserEntity) {
    console.log(`DELETE: ${user.userName}`);
  }

  onSearch() {
    if (this.searchForm.valid) {
      console.log("Search for user")
    }
  }
}
