import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-static-fields',
  templateUrl: './static-fields.component.html',
  styleUrls: ['./static-fields.component.less']
})
export class StaticFieldsComponent implements OnInit {
  @Input() label: string = '';
  @Input() text: string | null = '';

  constructor() { }

  ngOnInit(): void {
  }

}
