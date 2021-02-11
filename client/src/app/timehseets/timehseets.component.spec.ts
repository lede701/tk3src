import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimehseetsComponent } from './timehseets.component';

describe('TimehseetsComponent', () => {
  let component: TimehseetsComponent;
  let fixture: ComponentFixture<TimehseetsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TimehseetsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TimehseetsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
