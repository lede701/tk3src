import { Component, Input, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { TimesheetEntity } from '../../../entities/timesheets/timesheetEntity';
import { TimesheetsService } from '../../../services/timesheets.service';

@Component({
  selector: 'app-day-list',
  templateUrl: './day-list.component.html',
  styleUrls: ['./day-list.component.less']
})
export class DayListComponent implements OnInit {
  public dayList: string[] = [];
  public isToday: string = '';

  private _today = new Date();

  constructor(private tsService: TimesheetsService) {
  }

  ngOnInit(): void {
    let ts: TimesheetEntity;
    // Pull currently loaded timesheet
    this.tsService.currentTimesheet$.pipe(take(1)).subscribe(ts => {
      // Create dates for calulating the days in this timesheet
      let end: Date = new Date(ts.endDate);
      let day: Date = new Date(ts.startDate);
      // Build a list days
      while (day.valueOf() < end.valueOf()) {
        // Add current day to the list of days
        this.AddDateToList(day);
        // Check if the day is today
        this.IsDayToday(day);
        // Incrament day marker
        day.setDate(day.getDate() + 1);
      }
      // Add last day to timesheet
      this.AddDateToList(day);
      // Check if the last day is the current day
      this.IsDayToday(day);
    });
  }

  AddDateToList(day: Date) {
    let dayNames: Array<string> = ["Sun", "Mon", "Tue", "Wed", "Thur", "Fri", "Sat"];
    let dayFullNames: Array<string> = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];

    let monthName: Array<string> = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sept", "Oct", "Nov", "Dec"];
    let monthFullName: Array<string> = ["January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

    // Add the day label
    this.dayList.push(`${dayNames[day.getDay()]} ${day.getDate()}`);
  }

  IsDayToday(day: Date) {
    // Check if the day is the current 
    if (day.getDate() == this._today.getDate()
      && day.getMonth() == this._today.getMonth()
      && day.getFullYear() == this._today.getFullYear()) {
      // Set the current day label
      this.isToday = this.dayList[this.dayList.length - 1];
    }
  }

}
