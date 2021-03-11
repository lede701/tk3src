import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {
  busyRequestCount = 0;

  constructor(private spinner: NgxSpinnerService) { }

  busy() {
    this.busyRequestCount++;
    this.spinner.show(undefined, {
      type: 'ball-spin-clockwise',
      bdColor: 'rgba(150,150,150,0.5)',
      color: '#D18886',
      size: 'medium'
    });
  }

  idle() {
    this.busyRequestCount--;
    if (this.busyRequestCount <= 0) {
      this.busyRequestCount = 0;
      this.spinner.hide();
    }
  }
}
