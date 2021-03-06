import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { take } from 'rxjs/operators';
import { TimesheetEntity } from '../../../entities/timesheets/timesheetEntity';
import { TimesheetsService } from '../../../services/timesheets.service';

@Component({
  selector: 'app-day-list',
  templateUrl: './day-list.component.html',
  styleUrls: ['./day-list.component.less']
})
export class DayListComponent implements OnInit, OnDestroy {
  public dayList: string[] = [];
  public isToday: string = '';

  private _today = new Date();
  private _tsSubscription: Subscription;

  constructor(private tsService: TimesheetsService) {
    this._tsSubscription = tsService.currentTimesheet$.subscribe(ts => {
      this.dayList = [];
      this.isToday = '';
      let dayList = this.tsService.getDayList();
      // Process days in list
      for (let day of dayList) {
        // Add current day to the list of days
        this.AddDateToList(day);
        // Check if the day is today
        this.IsDayToday(day);
      }
    });
  }

  ngOnInit(): void {
    let ts: TimesheetEntity;
    // Pull currently loaded timesheet
    this.tsService.currentTimesheet$.pipe(take(1)).subscribe(ts => {

    });
  }

  ngOnDestroy(): void {
    this._tsSubscription?.unsubscribe();
  }

  AddDateToList(day: Date) {
    let dayNames: Array<string> = ["Sun", "Mon", "Tue", "Wed", "Thur", "Fri", "Sat"];
    let dayFullNames: Array<string> = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];

    let monthName: Array<string> = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sept", "Oct", "Nov", "Dec"];
    let monthFullName: Array<string> = ["January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];

    // Add the day label
    this.dayList.push(`${dayNames[day.getDay()]}<br />\r\n${day.getDate()}`);
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

  getDayClass(day: string): string {
    let extraClass = '';
    if (day.indexOf('Sat') >= 0 || day.indexOf('Sun') >= 0) {
      extraClass = ' day-weekend';
      if (day.indexOf('Sat') >= 0) {
        extraClass += ' border-weekend';
      }
    }
    return extraClass;
  }

}
