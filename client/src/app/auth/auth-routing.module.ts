import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthCreateComponent } from './auth-create/auth-create.component';
import { AuthComponent } from './auth.component';

const routes: Routes = [
  { path: 'auth/:task', component: AuthComponent },
  { path: 'auth/user/create', component: AuthCreateComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
