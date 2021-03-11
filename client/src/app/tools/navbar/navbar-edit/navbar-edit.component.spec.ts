import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavbarEditComponent } from './navbar-edit.component';

describe('NavbarEditComponent', () => {
  let component: NavbarEditComponent;
  let fixture: ComponentFixture<NavbarEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavbarEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NavbarEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
