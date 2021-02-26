import { Component, Input, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';

import { TimesheetEntity } from '../../entities/timesheets/timesheetEntity';
import { TimesheetsService } from '../../services/timesheets.service';

@Component({
  selector: 'app-sheetview',
  templateUrl: './sheetview.component.html',
  styleUrls: ['./sheetview.component.less']
})
export class SheetviewComponent implements OnInit {
  @Input() timesheet: TimesheetEntity = new TimesheetEntity();

  constructor(private tsServer: TimesheetsService) { }

  ngOnInit(): void {
    this.tsServer.currentTimesheet$.pipe(take(1)).subscribe(ts => {
      this.timesheet = ts;
    });
  }

  getFullName(): string {
    return `${this.timesheet.lastName}, ${this.timesheet.firstName}`;
  }

  getStartDate(): Date {
    return new Date(this.timesheet.startDate);
  }

}
