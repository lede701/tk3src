import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TimehseetsComponent } from './timehseets/timehseets.component';
import { SheetviewComponent } from './timesheets/sheetview/sheetview.component';
import { DayviewComponent } from './timesheets/dayview/dayview.component';
import { WeekviewComponent } from './timesheets/weekview/weekview.component';

@NgModule({
  declarations: [
    AppComponent,
    TimehseetsComponent,
    SheetviewComponent,
    DayviewComponent,
    WeekviewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
