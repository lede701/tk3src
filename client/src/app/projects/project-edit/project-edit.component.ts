import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { ProjectCodeEntity } from '../../entities/timesheets/projectCodeEntity';
import { ProjectsService } from '../projects.service';

@Component({
  selector: 'app-project-edit',
  templateUrl: './project-edit.component.html',
  styleUrls: ['./project-edit.component.less']
})
export class ProjectEditComponent implements OnInit {

  private _emptyGuid = '00000000-0000-0000-0000-000000000000';

  projectForm: FormGroup;
  public project: ProjectCodeEntity = {guid: '00000000-0000-0000-0000-000000000000', projectTitle: '',  projectDescription: '', statusCode: 1, commentType: 1 };
  public isEditable = true;
  public commentTypeList: any[] = [{ id: 1, value: 'Required' }, { id: 2, value: 'Optional' }, { id: 3, value: 'None'}]

  constructor(private projectService: ProjectsService, private activeRoute: ActivatedRoute, private route: Router, private fb: FormBuilder) {
    this.projectForm = this.fb.group({});
    this.InitializeForm();
  }

  ngOnInit(): void {
    let guid = this.activeRoute.snapshot.params?.guid;
    if (guid !== undefined) {
      this.isEditable = false;
      this.projectService.getProject(guid).pipe(take(1)).subscribe(results => {
        this.project = results;
        this.isEditable = true;
        this.InitializeForm();
      });
    }

  }

  private InitializeForm() {
    this.projectForm = this.fb.group({
      projectTitle: [this.project.projectTitle],
      projectDescription: [this.project.projectDescription],
      commentType: [this.project.commentType, [Validators.required]]
    });
  }

  onCancel() {
    console.log("Cancel we are");
    this.route.navigate(['/', 'projects']);
  }

  getEditType(): string {
    let type = 'New';
    if (this.project.guid != this._emptyGuid) type = 'Edit';
    return type;
  }

  store() {
    if (this.projectForm.valid) {
      let dto: ProjectCodeEntity = {
        guid: this.project.guid,
        statusCode: this.project.statusCode,
        projectTitle: this.projectForm.value?.projectTitle,
        projectDescription: this.projectForm.value?.projectDescription,
        commentType: this.projectForm.value?.commentType
      };
      this.projectService.store(dto).pipe(take(1)).subscribe(results => {
        console.log(results);
        this.route.navigate(['/', 'projects']);
      })
    }
  }
}
