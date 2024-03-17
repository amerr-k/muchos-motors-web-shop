import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { UserLoginInfo } from '../../shared/models/UserLoginInfo';
import {
  AuthenticationToken,
  UserAuthInfo,
} from '../../shared/models/UserAuthInfo';
import { AuthEndpoint } from '../../endpoints/auth-endpoint';
import { ToastrService } from 'ngx-toastr';
import { Customer } from '../../shared/models/Customer';

export interface IAuthService {
  login(userLoginInfo: UserLoginInfo): Observable<UserAuthInfo>;
  logout(): void;
  getAuthorizationToken(): AuthenticationToken | null;
  isLoggedIn: boolean;
  isCustomer: boolean;
  isEmployee: boolean;
  setAuthenticationToken(authenticationToken: AuthenticationToken | null): void;
  register(customer: Customer): Observable<any>;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService implements IAuthService {
  constructor(
    private authEndpoint: AuthEndpoint,
    private toastr: ToastrService
  ) {}

  login(userLoginInfo: UserLoginInfo): Observable<UserAuthInfo> {
    return this.authEndpoint.login(userLoginInfo).pipe(
      tap((response) => {
        this.setAuthenticationToken(response.authenticationToken);
      })
    );
  }

  logout(): void {
    this.authEndpoint.logout().subscribe({
      error: (err) => {
        this.setAuthenticationToken(null);
        this.toastr.error(err);
      },
      next: (r) => {
        this.setAuthenticationToken(null);
        this.toastr.success('Uspješno ste se odjavili');
      },
    });
  }

  getAuthorizationToken(): AuthenticationToken | null {
    let tokenString = window.localStorage.getItem('my-auth-token') ?? '';
    try {
      return JSON.parse(tokenString);
    } catch (e) {
      return null;
    }
  }

  register(customer: Customer): Observable<void> {
    return this.authEndpoint.register(customer);
  }

  get isLoggedIn(): boolean {
    return this.getAuthorizationToken() != null;
  }

  get isEmployee(): boolean {
    return this.getAuthorizationToken()?.userAccount.isEmployee ?? false;
  }

  get isCustomer(): boolean {
    return this.getAuthorizationToken()?.userAccount.isCustomer ?? false;
  }

  setAuthenticationToken(authenticationToken: AuthenticationToken | null) {
    if (authenticationToken == null) {
      window.localStorage.setItem('my-auth-token', '');
    } else {
      window.localStorage.setItem(
        'my-auth-token',
        JSON.stringify(authenticationToken)
      );
    }
  }
}
