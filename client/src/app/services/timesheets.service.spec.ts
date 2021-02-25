import { TestBed } from '@angular/core/testing';

import { TimesheetsService } from './timesheets.service';

describe('TimesheetsService', () => {
  let service: TimesheetsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TimesheetsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
