import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthComponent } from './auth/auth.component';
import { HomeComponent } from './home/home.component';
import { LeaveComponent } from './leave/leave.component';
import { MenuComponent } from './menu/menu.component';
import { TimesheetsComponent } from './timesheets/timesheets.component';
import { TimsheetCreateComponent } from './timesheets/timsheet-create/timsheet-create.component';

const routes: Routes = [
  {
    path: 'timesheet', component: TimesheetsComponent, children: [
    ]
  },
  {
    path: 'timesheet/sheet/:guid', component: TimesheetsComponent
  },
  {
    path: 'timesheet/create', component: TimsheetCreateComponent
  },
  { path: 'auth/:task', component: AuthComponent },
  { path: 'leave', component: LeaveComponent },
  { path: '', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
