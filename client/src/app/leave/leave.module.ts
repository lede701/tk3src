import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LeaveRoutingModule } from './leave-routing.module';
import { LeaveComponent } from './leave.component';


@NgModule({
  declarations: [
    LeaveComponent
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
