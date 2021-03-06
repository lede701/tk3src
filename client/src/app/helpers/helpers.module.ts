import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InputFieldComponent } from './input-field/input-field.component';
import { StaticFieldsComponent } from './static-fields/static-fields.component';
import { ToasterComponent } from './toaster/toaster.component';
import { ToastModule } from 'primeng/toast';
import { TableModule } from 'primeng/table';



@NgModule({
  declarations: [
    InputFieldComponent,
    StaticFieldsComponent,
    ToasterComponent
  ],
  imports: [
    CommonModule,
    ToastModule,
    TableModule,
  ],
  exports: [
    InputFieldComponent,
    StaticFieldsComponent,
    ToasterComponent
  ]
})
export class HelpersModule { }
