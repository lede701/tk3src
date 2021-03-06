import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TimesheetsRoutingModule } from './timesheets-routing.module';
import { TimesheetCreateComponent } from './timesheet-create/timesheet-create.component';
import { DayviewComponent } from './dayview/dayview.component';
import { SheetviewComponent } from './sheetview/sheetview.component';
import { TimesheetsComponent } from './timesheets.component';
import { HelpersModule } from '../helpers/helpers.module';
import { DayListComponent } from './sheetview/day-list/day-list.component';
import { ProjectListComponent } from './sheetview/project-list/project-list.component';


@NgModule({
  declarations: [
    TimesheetCreateComponent,
    DayviewComponent,
    SheetviewComponent,
    TimesheetsComponent,
    DayListComponent,
    ProjectListComponent

  ],
  imports: [
    CommonModule,
    TimesheetsRoutingModule,
    HelpersModule,
  ],
  exports: [
    TimesheetsComponent,
    DayviewComponent,
    SheetviewComponent,
    TimesheetCreateComponent
  ]
})
export class TimesheetsModule { }
