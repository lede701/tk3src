import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewmenuComponent } from './newmenu.component';

describe('NewmenuComponent', () => {
  let component: NewmenuComponent;
  let fixture: ComponentFixture<NewmenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewmenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewmenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
