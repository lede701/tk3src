import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { IIssue } from '../../entities/structure/issue';
import { IssuesService } from './issues.service';

@Component({
  selector: 'app-issues',
  templateUrl: './issues.component.html',
  styleUrls: ['./issues.component.less']
})
export class IssuesComponent implements OnInit {

  issues: IIssue[] = [];

  constructor(private issueService: IssuesService, private route: Router) { }

  ngOnInit(): void {
    this.issueService.issueList$.pipe(take(1)).subscribe(res => {
      this.issues = res;
    });
  }

  onIssueAdd() {
    this.route.navigate(['/', 'tools', 'issue', 'new']);

  }

  onIssueEdit(guid: string) {
    this.route.navigate(['/', 'tools', 'issue', 'edit', guid]);
  }

  onIssueDelete(guid: string) {

  }

}
