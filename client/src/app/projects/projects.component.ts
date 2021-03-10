import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ProjectCodeEntity } from '../entities/timesheets/projectCodeEntity';
import { ProjectsService } from './projects.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.less']
})
export class ProjectsComponent implements OnInit, OnDestroy {

  public projects: ProjectCodeEntity[] = [];

  private _projectSubscription: Subscription;

  constructor(private projectService: ProjectsService, private router: Router) {
    this._projectSubscription = this.projectService.currentList$.subscribe(results => {
      this.projects = results;
    });
  }
  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    this._projectSubscription?.unsubscribe();
  }
  
  edit(guid: string) {
    this.router.navigate(['/', 'projects', 'edit', guid]);
  }

  delete(guid: string) {
    console.log(guid);
  }

  onAddProject() {
    this.router.navigate(['/', 'projects', 'edit']);
  }
}
