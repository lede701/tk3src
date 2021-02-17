import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { TimesheetsComponent } from './timesheets/timesheets.component';

const routes: Routes = [
  {
    path: 'timesheet', component: TimesheetsComponent, children: [

    ]},
  { path: '', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
