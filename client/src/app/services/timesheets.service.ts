import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { environment } from '../../environments/environment';
import { TimesheetEntity } from '../entities/timesheets/timesheetEntity';
import { TimesheetListEntity } from '../entities/timesheets/timesheetListEntity';

@Injectable({
  providedIn: 'root'
})
export class TimesheetsService {
  private _baseUri = environment.apiUrl

  // Create observable for current timesheet
  private _currentTimesheet: ReplaySubject<TimesheetEntity> = new ReplaySubject<TimesheetEntity>(1);
  public currentTimesheet$ = this._currentTimesheet.asObservable();

  constructor(private http: HttpClient) { }

  getTimesheetList() {
    return this.http.get<TimesheetListEntity[]>(this._baseUri + '/Timesheet/list');
  }

  getTimesheet(guid: string): Observable<TimesheetEntity> {
    return this.http.get<TimesheetEntity>(this._baseUri + '/Timesheet/get/' + guid);
  }

  setTimesheet(ts: TimesheetEntity) {
    this._currentTimesheet.next(ts);
  }
}
