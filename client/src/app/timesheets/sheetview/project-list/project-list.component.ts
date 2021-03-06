import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { TimesheetEntity } from '../../../entities/timesheets/timesheetEntity';
import { TimesheetsService } from '../../../services/timesheets.service';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.less']
})
export class ProjectListComponent implements OnInit {
  public ts: TimesheetEntity = new TimesheetEntity();

  constructor(private tsService: TimesheetsService) { }

  ngOnInit(): void {
    this.tsService.currentTimesheet$.pipe(take(1)).subscribe(results => {
      this.ts = results;
      //console.log(this.ts);
    });
  }

}
