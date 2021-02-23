import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { UserEntity } from '../entities/userEntity';
import { Subject } from 'rxjs';
import { map } from 'rxjs/operators';

export interface AuthResponseData {
  idToken: string,
  email: string,
  refreshToken: string,
  expiresIn: string,
  localId: string,
  registered?: boolean
}

export interface AuthRefreshData {
  expires_in: string;
  token_type: string;
  refresh_token: string;
  id_token: string;
  user_id: string;
  project_id: string;
}

export interface Tk3AuthResponse {
  userName: string,
  token: string
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  private _user: UserEntity;
  private _keepAliveTimer: number = -1;

  public AuthChanged: Subject<UserEntity> = new Subject<UserEntity>();

  constructor(private http: HttpClient) {
    this._user = new UserEntity('0', '', '');
    let sess = localStorage.getItem('tk3user');
    if (sess) {
      let oSess = JSON.parse(sess);
      if (oSess) {
        this._user.id = oSess.id;
        this._user.username = oSess.username;
        this._user.isAuthenticated = oSess.isAuthenticated;
        this._user.tokenExpires = new Date(oSess.tokenExpires);
        this._user.refreshToken = oSess.refreshToken;
        // Check if token need to be updated and also start the tracking prodcess
        this.updateToken(this);
      }
    }
  }

  login(userName: string, password: string) {
    let login: any = {
      userName: userName,
      password: password
    };

    return this.http.post<Tk3AuthResponse>('https://localhost:5001/api/Auth/login', login).pipe(map(response => {
      let user = new UserEntity('0', response.userName, response.token);
      this._user = user;
      this._user.isAuthenticated = true;
      this.AuthChanged.next(this._user);
      localStorage.setItem('tk3user', JSON.stringify(this._user));
    }));
  }

  logout() {
    this._user = new UserEntity('0', '', '');
    localStorage.setItem('tk3user', JSON.stringify(this._user));
  }

  updateToken(src: AuthService) {
    let now = new Date();
    if (now > src._user.tokenExpires) {
      console.log("Update token");
    }
    let time = 15 * 60 * 1000;
    src._keepAliveTimer = setTimeout(src.updateToken, time, src);
  }

  getIsAuthenticated(): boolean {
    return this._user.isAuthenticated;
  }

  getName(): string {
    return this.getIsAuthenticated() ? this._user.username : '';
  }
}
