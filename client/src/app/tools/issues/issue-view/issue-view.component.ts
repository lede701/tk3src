import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { IIssue } from '../../../entities/structure/issue';
import { IIssueComment } from '../../../entities/structure/issuecomment';
import { IssuesService } from '../issues.service';

@Component({
  selector: 'app-issue-view',
  templateUrl: './issue-view.component.html',
  styleUrls: ['./issue-view.component.less']
})
export class IssueViewComponent implements OnInit {

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
  isValidIssue = false;
  commentForm: FormGroup;

  constructor(private active: ActivatedRoute, private route: Router, private issueService: IssuesService, fb: FormBuilder) {
    this.commentForm = fb.group({
      comment: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
    let guid = this.active.snapshot?.params?.guid;
    // Check if the guid is valid
    if (guid) {
      this.issueService.getIssue(guid).pipe(take(1)).subscribe(results => {
        this.issue = results;
        this.isValidIssue = true;
      });
    }
  }

  onAddComment() {
    if (this.commentForm.valid) {
      let issueComment: IIssueComment = {
        guid: '00000000-0000-0000-0000-000000000000',
        comment: this.commentForm.value.comment,
        rating: 0
      };

      this.issueService.addIssueComment(this.issue.guid, issueComment).pipe(take(1)).subscribe(results => {
        this.issue.comments.push(results);
        this.commentForm.reset();
      })

    }
  }

  onVoteUp(comment: IIssueComment) {
    this.issueService.issueCommentUp(comment.guid).pipe(take(1)).subscribe(results => {
      comment.rating = results.rating;
    });
  }

  onVoteDown(comment: IIssueComment) {
    this.issueService.issueCommentDown(comment.guid).pipe(take(1)).subscribe(results => {
      comment.rating = results.rating;
    });
  }

}
