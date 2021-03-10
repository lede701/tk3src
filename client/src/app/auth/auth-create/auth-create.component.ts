import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IRegsiterUserEntity } from '../../entities/iregisterUserEntity';
import { UserEntity } from '../../entities/userEntity';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-auth-create',
  templateUrl: './auth-create.component.html',
  styleUrls: ['./auth-create.component.less']
})
export class AuthCreateComponent implements OnInit {

  userForm: FormGroup;

  constructor(private auth: AuthService, private fb: FormBuilder, private route: Router) {
    this.userForm = this.fb.group({
      userName: ['', [Validators.required]],
      firstName: ['', [Validators.required]],
      middleName: ['', []],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      passwd: ['', [Validators.required, Validators.min(8)]],
      confirmpw: ['', [Validators.required, Validators.min(8)]]
    });
  }

  ngOnInit(): void {
  }

  onSaveUser() {
    if (this.userForm.value) {
      let dto: IRegsiterUserEntity = {
        firstName: this.userForm.value?.firstName,
        middleName: this.userForm.value?.middleName,
        lastName: this.userForm.value?.lastName,
        email: this.userForm.value?.email,
        userName: this.userForm.value?.userName,
        password: this.userForm.value?.passwd,
        confirm: this.userForm.value?.confirmpw
      };
      this.auth.create(dto);
      this.route.navigate(['/']);
    }
  }

}
