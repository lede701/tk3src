import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthCreateComponent } from './auth-create.component';

describe('AuthCreateComponent', () => {
  let component: AuthCreateComponent;
  let fixture: ComponentFixture<AuthCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
