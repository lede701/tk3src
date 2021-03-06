import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import { IResults } from '../../entities/iresults';
import { IIssue } from '../../entities/structure/issue';
import { IIssueComment } from '../../entities/structure/issuecomment';
import { IIssueType } from '../../entities/structure/issuetype';

@Injectable({
  providedIn: 'root'
})
export class IssuesService {
  private _baseUrl = environment.apiUrl + '/Issue';

  private _issueListSubject = new ReplaySubject<IIssue[]>(1);
  public issueList$ = this._issueListSubject.asObservable();

  constructor(private http: HttpClient) {
    this.getUpdateList().pipe(take(1)).subscribe(res => {

    });
  }

  public getUpdateList(): Observable<IIssue[]>{
    return this.http.get<IIssue[]>(this._baseUrl + '/list').pipe(map(results => {
      this._issueListSubject.next(results);
      return results;
    }));
  }

  public getIssue(guid: string) {
    return this.http.get<IIssue>(this._baseUrl + '/get/' + guid);
  }

  public getTypeList() {
    return this.http.get<IIssueType[]>(this._baseUrl + "/typelist");
  }

  public addIssueComment(guid: string, comment: IIssueComment) {
    return this.http.post<IIssueComment>(this._baseUrl + '/comment/add/' + guid, comment);
  }

  public issueCommentUp(guid: string) {
    return this.http.get<IIssueComment>(this._baseUrl + '/comment/up?guid=' + guid);
  }

  public issueCommentDown(guid: string) {
    return this.http.get<IIssueComment>(this._baseUrl + '/comment/down?guid=' + guid);
  }

  public issueStore(issue: IIssue) {
    return this.http.post<IResults>(this._baseUrl + '/store', issue);
  }
}
