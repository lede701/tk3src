import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { ProjectCodeEntity } from '../entities/timesheets/projectCodeEntity';

@Injectable({
  providedIn: 'root'
})
export class ProjectsService {

  private _baseUrl = environment.apiUrl + '/Project';

  private _projectList = new ReplaySubject<ProjectCodeEntity[]>();
  public currentList$ = this._projectList.asObservable();

  constructor(private http: HttpClient) {
    this.getAdminList();
  }

  getAdminList() {
    this.http.get<ProjectCodeEntity[]>(this._baseUrl + "/adminlist").subscribe(results => {
      this._projectList.next(results);
    });
  }

  getProject(guid: string) {
    return this.http.get<ProjectCodeEntity>(this._baseUrl + "/get/" + guid);
  }

  store(projectCode: ProjectCodeEntity) {
    return this.http.post(this._baseUrl + '/store', projectCode).pipe(
      map((results: ProjectCodeEntity|any) => {
        let list: ProjectCodeEntity[] = [];
        this.currentList$.pipe(take(1)).subscribe(pList => {
          list = pList;
        });
        list[list.indexOf(results)] = results;
        this._projectList.next(list);
      })
    );
  }
}
