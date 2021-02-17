import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SheetviewComponent } from './timesheets/sheetview/sheetview.component';
import { DayviewComponent } from './timesheets/dayview/dayview.component';
import { WeekviewComponent } from './timesheets/weekview/weekview.component';
import { TimesheetsComponent } from './timesheets/timesheets.component';
import { MenuComponent } from './menu/menu.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    SheetviewComponent,
    DayviewComponent,
    WeekviewComponent,
    TimesheetsComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
