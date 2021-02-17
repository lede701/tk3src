export class UserEntity {

  public isAuthenticated: boolean = false;
  public id: string = '';
  public username: string = '';

  public token: string = '';
  public refreshToken: string = '';
  public tokenExpires: Date = new Date();

  constructor(id: string, username: string, token: string) {
    this.id = id;
    this.username = username;
    this.token = token;
  }
}
