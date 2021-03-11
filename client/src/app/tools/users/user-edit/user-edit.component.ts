import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IUserEntity } from '../../../entities/iuserentity';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.less']
})
export class UserEditComponent implements OnInit {
  user: IUserEntity = {
    guid: '',
    userName: '',
    firstName: '',
    middleName: '',
    lastName: '',
    title: '',
    locationId: 1,
    departmentId: 1,
    workScheduleId: 1,
    accuralDate: new Date(),
    startDate: new Date(),
    terminationDate: null
  };

  constructor(private auth: AuthService, private route: Router, private active: ActivatedRoute) {

  }

  ngOnInit(): void {
    let guid = this.active.snapshot.params?.guid;
    console.log(guid);
  }

}
