import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LeaveComponent } from './leave.component';

const routes: Routes = [
  { path: 'leave', component: LeaveComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LeaveRoutingModule { }
