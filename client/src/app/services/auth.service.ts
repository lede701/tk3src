import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { UserEntity } from '../entities/userEntity';
import { Subject } from 'rxjs';

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
        this._user.isAuthenticated = oSess.isAuthenticated;
        this._user.tokenExpires = new Date(oSess.tokenExpires);
        this._user.refreshToken = oSess.refreshToken;
        // Check if token need to be updated and also start the tracking prodcess
        this.updateToken(this);
      }
    }

  }

  updateToken(src: AuthService) {
    let now = new Date();
    console.log("Update token");
    if (now > src._user.tokenExpires) {
    }
    let time = 15 * 1000;
    src._keepAliveTimer = setTimeout(src.updateToken, time, src);
  }

  getIsAuthenticated(): boolean {
    return this._user.isAuthenticated;
  }

  getName(): string {
    return "Username";
  }
}
