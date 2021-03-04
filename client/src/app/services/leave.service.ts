import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ILeave } from '../models/ileave';

@Injectable({ providedIn: 'root' })
export class LeaveService {
  private _baseUri;
  constructor(private http: HttpClient) {
    this._baseUri = environment.apiUrl;
  }

  public leaveList() {
    return this.http.get<ILeave[]>(this._baseUri + '/Leave/list');
  }
}
