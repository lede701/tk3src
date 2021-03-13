import { Component, OnInit } from '@angular/core';
import { ToasterService } from './toaster.service';
import { MessageService } from 'primeng/api'

@Component({
  selector: 'app-toaster',
  templateUrl: './toaster.component.html',
  styleUrls: ['./toaster.component.less'],
  providers: [MessageService]
})
export class ToasterComponent implements OnInit {

  constructor(private toast: ToasterService, private msgService: MessageService) { }

  ngOnInit(): void {
  }

  onClickMe() {
    console.log("Hit me, yes you did");
    this.msgService.add({
      key: 'notices',
      severity: "error",
      summary: "Toast",
      detail: "You have just been toasted!"
    });
  }
}
