import { Observable } from 'rxjs';
import { UserLoginInfo } from '../shared/models/UserLoginInfo';
import { UserAuthInfo } from '../shared/models/UserAuthInfo';
import { Injectable } from '@angular/core';
import { environment } from '../../../environment';
import { HttpClient } from '@angular/common/http';
import { createUrl } from '../shared/util/url-helper';
import { Customer } from '../shared/models/Customer';

export interface IAuthEndpoint {
  login(userLoginInfo: UserLoginInfo): Observable<UserAuthInfo>;
  logout(): Observable<any>;
  register(customer: Customer): Observable<any>;
}

@Injectable({
  providedIn: 'root',
})
export class AuthEndpoint implements IAuthEndpoint {
  private baseApiUrl = environment.baseApiUrl;
  private readonly authPath = 'auth';

  constructor(private http: HttpClient) {}

  public login(userLoginInfo: UserLoginInfo): Observable<UserAuthInfo> {
    const url = createUrl(this.baseApiUrl, this.authPath, 'login');
    return this.http.post<UserAuthInfo>(url, userLoginInfo);
  }

  public logout() {
    const url = createUrl(this.baseApiUrl, this.authPath, 'logout');
    return this.http.post(url, {});
  }

  public register(customer: Customer): Observable<any> {
    const url = createUrl(this.baseApiUrl, this.authPath, 'register');
    return this.http.post<any>(url, customer);
  }
}
