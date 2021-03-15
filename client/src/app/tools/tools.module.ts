import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ToolsRoutingModule } from './tools-routing.module';
import { ToolsComponent } from './tools.component';
import { NavbarComponent } from './navbar/navbar.component';
import { UsersComponent } from './users/users.component';
import { HelpersModule } from '../helpers/helpers.module';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { NavbarEditComponent } from './navbar/navbar-edit/navbar-edit.component';
import { IssuesComponent } from './issues/issues.component';
import { IssueEditComponent } from './issues/issue-edit/issue-edit.component';
import { IssueViewComponent } from './issues/issue-view/issue-view.component';


@NgModule({
  declarations: [
    ToolsComponent,
    NavbarComponent,
    UsersComponent,
    UserEditComponent,
    NavbarEditComponent,
    IssuesComponent,
    IssueEditComponent,
    IssueViewComponent
  ],
  imports: [
    CommonModule,
    ToolsRoutingModule,
    HelpersModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class ToolsModule { }
