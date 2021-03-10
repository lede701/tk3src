import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthCreateComponent } from './auth-create/auth-create.component';
import { AuthComponent } from './auth.component';
import { ResetpwComponent } from './resetpw/resetpw.component';

const routes: Routes = [
  { path: 'logout', component: AuthComponent },
  { path: 'whoami', component: AuthComponent },
  { path: 'resetpw', component: ResetpwComponent },
  { path: 'user/create', component: AuthCreateComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
