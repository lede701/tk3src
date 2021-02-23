import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { MenuComponent } from './menu/menu.component';
import { TimesheetsComponent } from './timesheets/timesheets.component';

const routes: Routes = [
  {
    path: 'timesheet', component: TimesheetsComponent, children: [

    ]
  },
  { path: 'auth/logout', component: MenuComponent},
  { path: '', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
