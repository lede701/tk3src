export class UserEntity {

  public isAuthenticated: boolean = false;
  public id: string = '0';
  public email: string = '';
  public username: string = '';
  public firstName: string = '';
  public middleName: string = '';
  public lastName: string = '';

  public token: string = '';
  public refreshToken: string = '';
  public tokenExpires: Date = new Date();
}
