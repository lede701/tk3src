import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { TimesheetEntity } from '../entities/timesheets/timesheetEntity';
import { TimesheetListEntity } from '../entities/timesheets/timesheetListEntity';

@Injectable({
  providedIn: 'root'
})
export class TimesheetsService {
  private _baseUri = environment.apiUrl

  constructor(private http: HttpClient) { }

  getTimesheetList() {
    return this.http.get<TimesheetListEntity[]>(this._baseUri + '/Timesheet/list');
  }

  getTimesheet(guid: string) {
    return this.http.get<TimesheetEntity>(this._baseUri + '/Timesheet/get/' + guid);
  }
}
