import { Component, OnInit } from '@angular/core';
import { OrderService } from '../services/order/order.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { Order } from '../shared/models/Order';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-order-details-page',
  templateUrl: './order-details-page.component.html',
  styleUrl: './order-details-page.component.css',
})
export class OrderDetailsPageComponent implements OnInit {
  order: Order;

  constructor(
    private orderService: OrderService,
    private toastr: ToastrService,
    private route: ActivatedRoute,
    private authService: AuthService,
    private router: Router
  ) {
    this.order = new Order();
  }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      if (params['id']) {
        this.orderService.getOrderById(params['id']).subscribe((response) => {
          this.order = response;
          console.log(this.order.orderItems);
          if (this.order.shippingDate == undefined) {
            this.order.shippingDate = new Date();
          }
        });
      }
    });
  }

  updateOrderDetails() {
    this.order.employeeId =
      this.authService.getAuthorizationToken()?.userAccountId;
    this.orderService.updateOrder(this.order).subscribe((response) => {
      this.router.navigate(['/order-page']);
      this.toastr.success('Uspješno ste evidentirali narudzbu');
    });
  }
}
