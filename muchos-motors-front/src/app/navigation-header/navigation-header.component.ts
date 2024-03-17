import { Component } from '@angular/core';
import { AuthService } from '../services/auth/auth.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-navigation-header',
  templateUrl: './navigation-header.component.html',
  styleUrl: './navigation-header.component.css',
})
export class NavigationHeaderComponent {
  constructor(
    public authService: AuthService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  logout() {
    this.authService.logout();
    this.router.navigate(['/']);
  }
}
