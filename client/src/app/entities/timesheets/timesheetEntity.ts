import { TimeDetailEntity } from './timeDetailsEntity';

export class TimesheetEntity {
  public guid: string = '';
  public earlySign: boolean = false;
  public positionDescription: string = '';
  public firstName: string = '';
  public middleName: string = '';
  public lastName: string = '';
  public hoursPerDay: number = 8.0;
  public hoursPerWeek: number = 40.0;
  public employeeStatus: number = 0;
  public startDate: Date = new Date();
  public endDate: Date = new Date();

  public timeDetails: TimeDetailEntity[] = [];
}
