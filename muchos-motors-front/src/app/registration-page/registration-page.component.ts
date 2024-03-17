import { Component, OnInit } from '@angular/core';
import { City } from '../shared/models/City';
import { Customer } from '../shared/models/Customer';
import { CityService } from '../services/city/city.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CustomerService } from '../services/customer/customer.service';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-registration-page',
  templateUrl: './registration-page.component.html',
  styleUrl: './registration-page.component.css',
})
export class RegistrationPageComponent implements OnInit {
  cities?: City[];
  customer: Customer;

  constructor(
    private authService: AuthService,
    private cityService: CityService,
    private router: Router,
    private toastr: ToastrService
  ) {
    this.customer = new Customer();
  }

  ngOnInit(): void {
    this.cityService.getAllCities().subscribe((response) => {
      this.cities = response;
    });
  }

  register() {
    if (this.customer) {
      this.authService.register(this.customer).subscribe({
        next: (response: any) => {
          this.toastr.success('Uspješno ste se registrovali', 'Čestitamo');
          this.router.navigateByUrl('/login-page');
        },
        error: (error: any) => {
          this.toastr.error(
            error.error.error.details,
            error.error.error.message
          );
        },
      });
    }
  }
}
