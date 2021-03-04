import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimsheetCreateComponent } from './timsheet-create.component';

describe('TimsheetCreateComponent', () => {
  let component: TimsheetCreateComponent;
  let fixture: ComponentFixture<TimsheetCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TimsheetCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TimsheetCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
