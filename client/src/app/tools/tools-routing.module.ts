import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IssueEditComponent } from './issues/issue-edit/issue-edit.component';
import { IssuesComponent } from './issues/issues.component';
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
  { path: 'issues', component: IssuesComponent },
  { path: 'issue/edit/:guid', component: IssueEditComponent },
  { path: 'issue/new', component: IssueEditComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ToolsRoutingModule { }
