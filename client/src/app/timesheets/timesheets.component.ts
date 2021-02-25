import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { take } from 'rxjs/operators';
import { TimesheetEntity } from '../entities/timesheets/timesheetEntity';
import { TimesheetListEntity } from '../entities/timesheets/timesheetListEntity';
import { TimesheetsService } from '../services/timesheets.service';

@Component({
  selector: 'app-timesheets',
  templateUrl: './timesheets.component.html',
  styleUrls: ['./timesheets.component.less']
})
export class TimesheetsComponent implements OnInit {
  @ViewChild('tsSelect') timesheetSelector: ElementRef;
  public timesheetList: TimesheetListEntity[] = [];

  public timesheet: TimesheetEntity = new TimesheetEntity();

  constructor(private tsService: TimesheetsService) { }

  ngOnInit(): void {
    this.tsService.getTimesheetList().pipe(take(1)).subscribe(response => {
      this.timesheetList = response;
      console.log(response);
    });
  }

  onChangeTimesheet() {
    this.tsService.getTimesheet(this.timesheetSelector.nativeElement.value).pipe(take(1)).subscribe(results => {
      
    });
  }

}
