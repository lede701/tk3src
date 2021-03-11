import { Component, OnInit } from '@angular/core';
import { ToolsService } from './tools.service';

@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styleUrls: ['./tools.component.less']
})
export class ToolsComponent implements OnInit {

  constructor(private tools: ToolsService) { }

  ngOnInit(): void {
  }

}
