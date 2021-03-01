import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgbDropdownModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SheetviewComponent } from './timesheets/sheetview/sheetview.component';
import { DayviewComponent } from './timesheets/dayview/dayview.component';
import { WeekviewComponent } from './timesheets/weekview/weekview.component';
import { TimesheetsComponent } from './timesheets/timesheets.component';
import { MenuComponent } from './menu/menu.component';
import { HomeComponent } from './home/home.component';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { AuthComponent } from './auth/auth.component';
import { StaticFieldsComponent } from './helpers/static-fields/static-fields.component';
import { DayListComponent } from './timesheets/sheetview/day-list/day-list.component';

@NgModule({
  declarations: [
    AppComponent,
    SheetviewComponent,
    DayviewComponent,
    WeekviewComponent,
    TimesheetsComponent,
    MenuComponent,
    HomeComponent,
    AuthComponent,
    StaticFieldsComponent,
    DayListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgbModule,
    NgbDropdownModule,
    FormsModule,
  ],
  exports: [
    FormsModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
