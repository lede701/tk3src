export interface IUserEntity {
  guid: string;
  userName: string;
  firstName: string;
  middleName: string;
  lastName: string;
  title: string;
  locationId: number;
  departmentId: number;
  workScheduleId: number;
  startDate: Date;
  terminationDate: Date | null;
  accuralDate: Date;
}
