import { Component, OnInit } from '@angular/core';
import { Cart } from '../shared/models/Cart';
import { CartService } from '../services/cart/cart.service';
import { Customer } from '../shared/models/Customer';
import { City } from '../shared/models/City';
import { CityService } from '../services/city/city.service';
import { Order } from '../shared/models/Order';
import { OrderService } from '../services/order/order.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-checkout-page',
  templateUrl: './checkout-page.component.html',
  styleUrl: './checkout-page.component.css',
})
export class CheckoutPageComponent implements OnInit {
  cart!: Cart;
  order: Order = new Order();
  cities?: City[];
  customer: Customer;

  constructor(
    private cartService: CartService,
    private cityService: CityService,
    private orderService: OrderService,
    private router: Router,
    private toastr: ToastrService,
    private authService: AuthService
  ) {
    this.customer = new Customer();
  }

  ngOnInit(): void {
    this.cart = this.cartService.getCart();

    if (this.authService.isLoggedIn) {
      let customer = this.authService.getAuthorizationToken()?.userAccount;
      this.order.customerFirstName = customer?.firstName;
      this.order.customerLastName = customer?.lastName;
      this.order.customerEmail = customer?.email;
      this.order.customerShippingAddress = customer?.address;
      this.order.customerPhone = customer?.phone;
      this.order.customerShippingCityId = customer?.cityId;
      this.order.customerId = customer?.userAccountId;
    }

    this.cityService.getAllCities().subscribe((response) => {
      this.cities = response;
    });
  }
  createOrder() {
    if (this.order) {
      this.order.orderItems = this.cart.items;
      this.order.totalPrice = this.cart.totalPrice;
      this.orderService.createOrder(this.order).subscribe({
        next: (response: any) => {
          this.toastr.success('Uspješno ste kreirali narudžbu', 'Čestitamo');
          this.router.navigateByUrl('/');
        },
        error: (error: any) => {
          this.toastr.error(error.error.title);
        },
      });
    }
  }
}
