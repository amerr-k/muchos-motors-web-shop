import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { UserLoginInfo } from '../shared/models/UserLoginInfo';
import { AuthService } from '../services/auth/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css',
})
export class LoginPageComponent implements OnInit {
  public userLoginInfo: UserLoginInfo = {
    password: '',
    username: '',
  };
  constructor(
    public httpClient: HttpClient,
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}

  signIn() {
    this.authService.login(this.userLoginInfo).subscribe((x) => {
      if (!x.isLoggedIn) {
        this.toastr.error('Pogrešni kredencijali. Pokušajte ponovo');
      } else {
        this.authService.setAuthenticationToken(x.authenticationToken);
        this.toastr.success('Uspješno ste se prijavili');

        this.route.queryParams.subscribe((params) => {
          const redirectUrl = params['redirectUrl'];

          if (redirectUrl) {
            this.router.navigate([redirectUrl]);
          } else {
            if (this.authService.isEmployee) {
              this.router.navigate(['/inventory-page']);
            } else {
              this.router.navigate(['/']);
            }
          }
        });
      }
    });
  }
}
