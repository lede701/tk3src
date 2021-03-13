import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { IIssue } from '../../../entities/structure/issue';
import { IssuesService } from '../issues.service';

@Component({
  selector: 'app-issue-edit',
  templateUrl: './issue-edit.component.html',
  styleUrls: ['./issue-edit.component.less']
})
export class IssueEditComponent implements OnInit {
  issue: IIssue = {
    guid: '',
    issueDescription: '',
    issueTitle: '',
    issueType: {
      guid: '',
      typeTag: ''
    },
    severity: 0
  };

  constructor(private active: ActivatedRoute, private route: Router, private issueService: IssuesService) { }

  ngOnInit(): void {
    let guid = this.active.snapshot?.params?.guid;
    if (guid != undefined) {
      this.issueService.getIssue(guid).pipe(take(1)).subscribe(results => {
        this.issue = results;
      });
    }
  }

}
