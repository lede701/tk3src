import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { UserEntity } from '../entities/userEntity';
import { ReplaySubject, Subject } from 'rxjs';
import { environment } from '../../environments/environment';
import { map, take } from 'rxjs/operators';

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

export interface WhoAmIResponse {
  username: String
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  private storeKey: string = 'tk3user';
  private _user: UserEntity;
  private _keepAliveTimer: number = -1;
  private _baseUri: string = environment.apiUrl;

  private _currentUserSource = new ReplaySubject<UserEntity>(1);
  currentUser$ = this._currentUserSource.asObservable();

  constructor(private http: HttpClient) {
    this._user = new UserEntity();
    let sess = localStorage.getItem(this.storeKey);
    if (sess) {
      let oSess = JSON.parse(sess);
      if (oSess) {
        this._user.id = oSess.id;
        this._user.token = oSess.token;
        this._user.username = oSess.username;
        this._user.isAuthenticated = oSess.isAuthenticated;
        this._user.tokenExpires = new Date(oSess.tokenExpires);
        this._user.refreshToken = oSess.refreshToken;
        this._currentUserSource.next(this._user);
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
    return this.http.post<Tk3AuthResponse>(this._baseUri + '/Auth/login', login).pipe(map(results => {
      let user: UserEntity = new UserEntity();
      user.isAuthenticated = true;
      user.username = results.userName;
      user.token = results.token;
      user.id = "0";
      this._user = user;
      this._currentUserSource.next(this._user);
      localStorage.setItem(this.storeKey, JSON.stringify(this._user));
      console.log(results);
    }));
  }

  logout() {
    this.http.post(this._baseUri + '/Auth/logout', { username: this._user.username }).pipe(take(1)).subscribe(() => {
    });
    this._user = new UserEntity();
    localStorage.removeItem(this.storeKey);
    this._currentUserSource.next(this._user);
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

  WhoAmI() {
    return this.http.get<WhoAmIResponse>(this._baseUri + '/Auth/whoami');
  }
}
