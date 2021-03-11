import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { IPasswordReset } from '../../entities/ipasswordreset';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-resetpw',
  templateUrl: './resetpw.component.html',
  styleUrls: ['./resetpw.component.less']
})
export class ResetpwComponent implements OnInit {
  pwForm: FormGroup;

  constructor(fb: FormBuilder, private auth: AuthService, private route: Router) {
    this.pwForm = fb.group({
      currentPw: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.min(8)]],
      confirm: ['', [Validators.required, Validators.min(8)]]
    });
  }

  ngOnInit(): void {
  }

  onUpdatePw() {
    if (this.pwForm.valid) {
      let dto: IPasswordReset = {
        originalPassword: this.pwForm.value?.currentPw,
        password: this.pwForm.value?.password,
        confirmPassword: this.pwForm.value?.confirm
      };
      this.auth.resetPassword(dto).pipe(take(1)).subscribe(results => {
        this.route.navigate(['/']);
      });
    }
  }

}
