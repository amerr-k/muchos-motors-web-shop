import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { AuthService } from '../../../services/auth/auth.service';

@Injectable()
export class EmployeeMethodsGuard implements CanActivate {
  constructor(private router: Router, private authService: AuthService) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (this.authService.isLoggedIn) {
      let isCustomer = this.authService.isCustomer;

      if (isCustomer) {
        this.router.navigate(['/login-page']);
        return false;
      }

      return true;
    }

    this.router.navigate(['/login-page'], {
      queryParams: { redirectUrl: state.url },
    });
    return false;
  }
}
