import { Injectable } from '@angular/core';
import {
  HttpErrorResponse,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { tap } from 'rxjs';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth/auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService, private router: Router) {}

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const authToken = this.authService.getAuthorizationToken()?.value ?? '';
    const authReq = req.clone({
      headers: req.headers.set('my-auth-token', authToken),
    });

    return next.handle(authReq).pipe(
      tap(
        () => {},
        (err) => {
          if (err instanceof HttpErrorResponse) {
            if (err.status !== 401) {
              return;
            }

            this.router.navigateByUrl('/auth/login');
          }
        }
      )
    );
  }
}
