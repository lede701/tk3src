import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthComponent } from './auth/auth.component';
import { HomeComponent } from './home/home.component';
import { LeaveComponent } from './leave/leave.component';
import { MenuComponent } from './menu/menu.component';
import { NewmenuComponent } from './menu/newmenu/newmenu.component';
import { TimesheetsComponent } from './timesheets/timesheets.component';

const routes: Routes = [
  { path: 'mega', component: NewmenuComponent },
  { path: 'auth/:task', component: AuthComponent },
  { path: 'leave', component: LeaveComponent },
  { path: '', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
