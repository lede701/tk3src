import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NavbarEditComponent } from './navbar/navbar-edit/navbar-edit.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ToolsComponent } from './tools.component';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
  { path: '', component: ToolsComponent },
  { path: 'navbar', component: NavbarComponent },
  { path: 'navbar/:guid', component: NavbarEditComponent },
  { path: 'users', component: UsersComponent },
  { path: 'users/:guid', component: UserEditComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ToolsRoutingModule { }
