import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthComponent } from './auth/auth.component';
import { HomeComponent } from './home/home.component';
import { TimesheetsComponent } from './timesheets/timesheets.component';

const routes: Routes = [
  {
    path: 'timesheet', component: TimesheetsComponent, children: [

    ]
  },
  { path: 'auth/:task', component: AuthComponent},
  { path: '', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
