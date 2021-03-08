import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TimesheetCreateComponent } from './timesheet-create/timesheet-create.component';
import { TimesheetsComponent } from './timesheets.component';

const routes: Routes = [
  { path: 'timesheet', component: TimesheetsComponent, children: [] },
  {
    path: 'timesheet/sheet/:guid', component: TimesheetsComponent
  },
  {
    path: 'timesheet/create', component: TimesheetCreateComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TimesheetsRoutingModule { }
