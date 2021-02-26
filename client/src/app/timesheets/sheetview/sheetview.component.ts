import { Component, Input, OnInit } from '@angular/core';
import { TimesheetEntity } from '../../entities/timesheets/timesheetEntity';

@Component({
  selector: 'app-sheetview',
  templateUrl: './sheetview.component.html',
  styleUrls: ['./sheetview.component.less']
})
export class SheetviewComponent implements OnInit {
  @Input() timesheet: TimesheetEntity;

  constructor() { }

  ngOnInit(): void {
    console.log(this.timesheet);
  }

}
