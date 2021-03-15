import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { IIssue } from '../../../entities/structure/issue';
import { IIssueType } from '../../../entities/structure/issuetype';
import { IssuesService } from '../issues.service';

@Component({
  selector: 'app-issue-edit',
  templateUrl: './issue-edit.component.html',
  styleUrls: ['./issue-edit.component.less']
})
export class IssueEditComponent implements OnInit {
  issue: IIssue = {
    guid: '00000000-0000-0000-0000-000000000000',
    issueDescription: '',
    issueTitle: '',
    issueType: {
      guid: '',
      typeTag: ''
    },
    severity: 0,
    comments: []
  };

  issueForm: FormGroup;
  isEditable = true;
  issueTypeList: IIssueType[] = [];

  constructor(private active: ActivatedRoute, private route: Router, private issueService: IssuesService, private fb: FormBuilder) {
    // Initialize issue for lint
    this.issueForm = this.fb.group({
      title: [this.issue.issueTitle, [Validators.required]],
      description: [this.issue.issueDescription, [Validators.required]],
      severity: [this.issue.severity, [Validators.required]],
      issueType: [this.issue.issueType.guid, []]
    });
  }

  ngOnInit(): void {
    // Get issue guid from activated route
    let guid = this.active.snapshot?.params?.guid;
    // Set editable false while we load the list of issue types.
    this.isEditable = false;
    this.issueService.getTypeList().pipe(take(1)).subscribe(list => {
      // Set the issue type list
      this.issueTypeList = list;
      // Find new item option in list
      for (let type of list) {
        if (type.typeTag == 'New') {
          this.issueForm.controls.issueType.setValue(type.guid);
          break;
        }
      }
      // Enable editing
      this.isEditable = true;
    });

    // Check if we have a valid guid
    if (guid != undefined) {
      // Turn editing off while we load the data.
      this.isEditable = false;
      this.issueService.getIssue(guid).pipe(take(1)).subscribe(results => {
        // Bind data to issue variable
        this.issue = results;
        // Build form binding to retrieved issue
        this.issueForm = this.fb.group({
          title: [this.issue.issueTitle, [Validators.required]],
          description: [this.issue.issueDescription, [Validators.required]],
          severity: [this.issue.severity, []],
          issueType: [this.issue.issueType.guid, []]
        });
        // Done retrieving data so allow editing
        this.isEditable = true;
      });
    }
  }

  issueHeading() {
    // Check if issue is loaded
    if (this.issue.guid != '00000000-0000-0000-0000-000000000000') return 'Update Issue'
    // Return new issue header
    return 'Create Issue';
  }

  onStore() {
    if (this.issueForm.valid) {
      // Bind form data back to issue entity
      this.issue.issueTitle = this.issueForm.value.title;
      this.issue.issueDescription = this.issueForm.value.description;
      this.issue.severity = this.issueForm.value.severity;
      this.issue.issueType.guid = this.issueForm.value.issueType;
      // Send issue to APIy

      this.issueService.issueStore(this.issue).pipe(take(1)).subscribe(results => {
        // Check respose results
        if (results.success) {
          this.issueService.getUpdateList().pipe(take(1)).subscribe(results => {
            this.route.navigate(['/', 'tools', 'issues']);
          });
        } else {
          console.error(results);
        }
      });
    }
  }

  onCancel() {
    this.route.navigate(['/', 'tools', 'issues']);
  }

}
