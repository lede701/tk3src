import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { NgbDropdownModule, NgbModule, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastModule } from 'primeng/toast';
import { TableModule } from 'primeng/table';
import { MessageService } from 'primeng/api'
import { MenuModule } from 'primeng/menu';
import { MenubarModule } from 'primeng/menubar';

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
import { ProjectListComponent } from './timesheets/sheetview/project-list/project-list.component';
import { TimsheetCreateComponent } from './timesheets/timsheet-create/timsheet-create.component';
import { AuthCreateComponent } from './auth/auth-create/auth-create.component';
import { InputFieldComponent } from './helpers/input-field/input-field.component';
import { LeaveComponent } from './leave/leave.component';
import { ToasterComponent } from './helpers/toaster/toaster.component';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { NewmenuComponent } from './menu/newmenu/newmenu.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoadingInterceptor } from './interceptors/loading.interceptor';

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
    DayListComponent,
    ProjectListComponent,
    TimsheetCreateComponent,
    AuthCreateComponent,
    InputFieldComponent,
    LeaveComponent,
    ToasterComponent,
    NewmenuComponent,
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    NgbModule,
    NgbDropdownModule,
    ToastModule,
    TableModule,
    MenuModule,
    MenubarModule,
    NgxSpinnerModule,
  ],
  exports: [
    FormsModule,
    ToastModule,
    TableModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
