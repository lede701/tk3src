export interface ILeave {
  guid: string;
  tranType: string;
  tranTime: number;
  tranDate: Date;
  displayDate: Date;
  employeeSigned: boolean;
  approved: boolean;
  isAccrual: boolean;
  bankName: string;
  bankCode: string;
}
