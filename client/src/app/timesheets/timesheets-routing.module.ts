import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TimesheetCreateComponent } from './timesheet-create/timesheet-create.component';
import { TimesheetsComponent } from './timesheets.component';

const routes: Routes = [
  { path: '', component: TimesheetsComponent, children: [] },
  {
    path: 'sheet/:guid', component: TimesheetsComponent
  },
  {
    path: 'create', component: TimesheetCreateComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TimesheetsRoutingModule { }
