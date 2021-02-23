export class UserEntity {

  public isAuthenticated: boolean = false;
  public id: string = '0';
  public username: string = '';

  public token: string = '';
  public refreshToken: string = '';
  public tokenExpires: Date = new Date();
}
