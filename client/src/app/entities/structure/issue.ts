import { IIssueComment } from './issuecomment';
import { IIssueType } from './issuetype';

export interface IIssue {
  guid: string;
  issueTitle: string;
  issueDescription: string;
  severity: number;
  issueType: IIssueType;
  comments: IIssueComment[];
}
