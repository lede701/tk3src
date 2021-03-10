import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'auth', loadChildren: () => import('./auth/auth.module').then(mod => mod.AuthModule), data: {} },
  { path: 'timesheet', loadChildren: () => import('./timesheets/timesheets.module').then(mod => mod.TimesheetsModule), data: {} },
  { path: 'sheetview', loadChildren: () => import('./timesheets/timesheets.module').then(mod => mod.TimesheetsModule), data: {} },
  { path: 'leave', loadChildren: () => import('./leave/leave.module').then(mod => mod.LeaveModule), data: {} },
  { path: 'projects', loadChildren: () => import('./projects/projects.module').then(mod => mod.ProjectsModule), data: {} },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
