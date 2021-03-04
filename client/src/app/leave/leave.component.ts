import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { ILeave } from '../models/ileave';
import { LeaveService } from '../services/leave.service';

@Component({
  selector: 'app-leave',
  templateUrl: './leave.component.html',
  styleUrls: ['./leave.component.less']
})
export class LeaveComponent implements OnInit {

  public leave: ILeave[] = [];
  public row: number = 0;

  constructor(private lvService: LeaveService) { }

  ngOnInit(): void {
    this.lvService.leaveList().pipe(take(1)).subscribe(results => {
      this.leave = results;
    });
  }

  public getRowNumber() {
    return 1;
  }

  public getTranType(type: string): string {
    switch (type) {
      case 'C':
        return 'Credit';
    }
    return "";
  }
}
