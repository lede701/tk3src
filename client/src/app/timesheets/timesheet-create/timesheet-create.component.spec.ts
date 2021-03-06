import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimesheetCreateComponent } from './timesheet-create.component';

describe('TimesheetCreateComponent', () => {
  let component: TimesheetCreateComponent;
  let fixture: ComponentFixture<TimesheetCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TimesheetCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TimesheetCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
