import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LeaveRoutingModule } from './leave-routing.module';
import { LeaveComponent } from './leave.component';
import { LeaveEditComponent } from './leave-edit/leave-edit.component';


@NgModule({
  declarations: [
    LeaveComponent,
    LeaveEditComponent
  ],
  imports: [
    CommonModule,
    LeaveRoutingModule
  ],
  exports: [
    LeaveComponent
  ]
})
export class LeaveModule { }
