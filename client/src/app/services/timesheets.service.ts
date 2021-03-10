import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { TimesheetEntity } from '../entities/timesheets/timesheetEntity';
import { TimesheetListEntity } from '../entities/timesheets/timesheetListEntity';

@Injectable({
  providedIn: 'root'
})
export class TimesheetsService {
  private _baseUri = environment.apiUrl

  private _dayList: Date[] = [];

  // Create observable for current timesheet
  private _currentTimesheet: ReplaySubject<TimesheetEntity> = new ReplaySubject<TimesheetEntity>(1);
  public currentTimesheet$ = this._currentTimesheet.asObservable();

  constructor(private http: HttpClient) { }

  getTimesheetList() {
    return this.http.get<TimesheetListEntity[]>(this._baseUri + '/Timesheet/list');
  }

  getTimesheet(guid: string): Observable<TimesheetEntity> {
    return this.http.get<TimesheetEntity>(this._baseUri + '/Timesheet/get/' + guid).pipe(map(ts => {
      this.setTimesheet(ts);
      return ts;
    }));
  }

  public getDayList(): Date[] {
    return [...this._dayList];
  }

  setTimesheet(ts: TimesheetEntity) {
    this.createListOfDays(ts);
    this._currentTimesheet.next(ts);
  }

  private createListOfDays(ts: TimesheetEntity) {
    // Clear list of days
    this._dayList = [];

    let end: Date = new Date(ts.endDate);
    let day: Date = new Date(ts.startDate);
    // Build a list days
    while (day.valueOf() < end.valueOf()) {
      // Add current day to the list of days
      this._dayList.push(new Date(day));
      // Incrament day marker
      day.setDate(day.getDate() + 1);
    }
    this._dayList.push(new Date(day));

  }
}
