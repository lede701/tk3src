import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { HelpersModule } from "../helpers/helpers.module";
import { ProjectsRoutingModule } from './projects-routing.module';
import { ProjectsComponent } from './projects.component';
import { ProjectEditComponent } from './project-edit/project-edit.component';


@NgModule({
  declarations: [ProjectsComponent, ProjectEditComponent],
  imports: [
    CommonModule,
    ProjectsRoutingModule,
    HelpersModule,
    FormsModule,
    ReactiveFormsModule,
  ]
})
export class ProjectsModule { }
