import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { AuthComponent } from './auth.component';
import { AuthCreateComponent } from './auth-create/auth-create.component';
import { HelpersModule } from '../helpers/helpers.module';
import { ResetpwComponent } from './resetpw/resetpw.component';


@NgModule({
  declarations: [
    AuthComponent,
    AuthCreateComponent,
    ResetpwComponent
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    HelpersModule,
  ],
  exports: [
    AuthComponent,
    AuthCreateComponent,
  ]
})
export class AuthModule { }
