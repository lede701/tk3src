import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { take } from 'rxjs/operators';
import { TimesheetEntity } from '../../../entities/timesheets/timesheetEntity';
import { TimesheetsService } from '../../../services/timesheets.service';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.less']
})
export class ProjectListComponent implements OnInit, OnDestroy {
  public ts: TimesheetEntity = new TimesheetEntity();
  public dayList: Date[] = [];

  private _tsSubscription: Subscription;

  constructor(private tsService: TimesheetsService) {
    this._tsSubscription = tsService.currentTimesheet$.subscribe(ts => {
      this.ts = ts;
      this.dayList = [];
      this.setupProjects();
    });
  }

  ngOnInit(): void {
    this.tsService.currentTimesheet$.pipe(take(1)).subscribe(results => {
      this.ts = results;
      //console.log(this.ts);
    });
  }

  ngOnDestroy(): void {
    this._tsSubscription?.unsubscribe();
  }

  private setupProjects() {
    this.dayList = this.tsService.getDayList();
    console.log(this.ts.timeDetails);

  }

}
