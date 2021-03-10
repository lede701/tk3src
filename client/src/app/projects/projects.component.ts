import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { take } from 'rxjs/operators';
import { ProjectCodeEntity } from '../entities/timesheets/projectCodeEntity';
import { ProjectsService } from './projects.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.less']
})
export class ProjectsComponent implements OnInit, OnDestroy {

  public projects: ProjectCodeEntity[] = [];

  constructor(private projectService: ProjectsService, private router: Router) {}

  ngOnInit(): void {
    this.projectService.currentList$.pipe(take(1)).subscribe(results => {
      this.projects = results;
    });
  }

  ngOnDestroy(): void {
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
