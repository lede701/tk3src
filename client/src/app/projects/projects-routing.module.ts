import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProjectEditComponent } from './project-edit/project-edit.component';
import { ProjectsComponent } from './projects.component';

const routes: Routes = [
  { path: "", component: ProjectsComponent },
  { path: "edit", component: ProjectEditComponent },
  { path: "edit/:guid", component: ProjectEditComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjectsRoutingModule { }
