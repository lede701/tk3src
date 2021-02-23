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

export interface Tk3AuthResponse {
  userName: string,
  token: string
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  private _user: UserEntity;
  private _keepAliveTimer: number = -1;
  private _baseUri: string = environment.apiUrl;

  public AuthChanged: Subject<UserEntity> = new Subject<UserEntity>();
  private _currentUserSource = new ReplaySubject<UserEntity>(1);
  currentUser$ = this._currentUserSource.asObservable();

  constructor(private http: HttpClient) {
    this._user = new UserEntity();
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
    return this.http.post('https://localhost:5001/api/Auth/login', login);
  }

  logout() {
    this.http.post(this._baseUri + '/Auth/login', { username: this._user.username }).pipe(take(1)).subscribe(() => {
      this._user = new UserEntity();
      localStorage.removeItem('tk3user');
      this._currentUserSource.next(this._user);
    });
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
