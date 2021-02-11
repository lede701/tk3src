import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SheetviewComponent } from './sheetview.component';

describe('SheetviewComponent', () => {
  let component: SheetviewComponent;
  let fixture: ComponentFixture<SheetviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SheetviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SheetviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
