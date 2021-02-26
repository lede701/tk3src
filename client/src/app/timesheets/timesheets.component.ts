import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { TimesheetListEntity } from '../entities/timesheets/timesheetListEntity';
import { TimesheetsService } from '../services/timesheets.service';

@Component({
  selector: 'app-timesheets',
  templateUrl: './timesheets.component.html',
  styleUrls: ['./timesheets.component.less']
})
export class TimesheetsComponent implements OnInit {
  @ViewChild('tsSelect') timesheetSelector: ElementRef = new ElementRef({});
  public timesheetList: TimesheetListEntity[] = [];

  public isTimesheetLoaded: boolean = false;

  constructor(private tsService: TimesheetsService, private activeRoute: ActivatedRoute, private route: Router) { }

  ngOnInit(): void {
    let tsGuid = this.activeRoute.snapshot.params.guid;

    this.tsService.getTimesheetList().pipe(take(1)).subscribe(response => {
      this.timesheetList = response;
    });
    if (tsGuid !== undefined) {
      this.loadTimesheet(tsGuid);
    }
  }

  onChangeTimesheet(timesheetItem: any) {
    let tsGuid = this.timesheetSelector.nativeElement.value;
    this.route.navigate(['/', 'timesheet', tsGuid]);
  }

  loadTimesheet(tsGuid: string) {
    this.isTimesheetLoaded = false;
    if (tsGuid.length > 0) {
      this.tsService.getTimesheet(tsGuid).pipe(take(1)).subscribe(results => {
        this.tsService.setTimesheet(results);
        this.isTimesheetLoaded = true;
      });
    }
  }

}
