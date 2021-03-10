import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { take } from 'rxjs/operators';

import { TimesheetEntity } from '../../entities/timesheets/timesheetEntity';
import { TimesheetsService } from '../../services/timesheets.service';

@Component({
  selector: 'app-sheetview',
  templateUrl: './sheetview.component.html',
  styleUrls: ['./sheetview.component.less']
})
export class SheetviewComponent implements OnInit, OnDestroy {
  @Input() timesheet: TimesheetEntity = new TimesheetEntity();

  private _tsSubscription: Subscription;

  constructor(private tsService: TimesheetsService) {
    this._tsSubscription = this.tsService.currentTimesheet$.subscribe(ts => {
      this.timesheet = ts;
    });
  }

  ngOnInit(): void { }

  ngOnDestroy(): void {
    if (this._tsSubscription) {
      this._tsSubscription.unsubscribe();
    }
  }

  getFullName(): string {
    return `${this.timesheet.lastName}, ${this.timesheet.firstName}`;
  }

  getStartDate(): Date {
    return new Date(this.timesheet.startDate);
  }

  getEmployeeStatus(): string {
    switch (this.timesheet.employeeStatus) {
      case 1:
        return "Exempt";
      case 2:
        return "Non-Exempt";
      case 3:
        return "Part-Time";
    }

    return "undefined";
  }

  getNumberOfHours(): string {
    return "0";
  }

}
