import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SheetviewComponent } from './timesheets/sheetview/sheetview.component';
import { DayviewComponent } from './timesheets/dayview/dayview.component';
import { WeekviewComponent } from './timesheets/weekview/weekview.component';
import { TimesheetsComponent } from './timesheets/timesheets.component';

@NgModule({
  declarations: [
    AppComponent,
    SheetviewComponent,
    DayviewComponent,
    WeekviewComponent,
    TimesheetsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
