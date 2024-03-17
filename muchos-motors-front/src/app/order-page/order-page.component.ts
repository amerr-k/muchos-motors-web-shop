import { Component, OnInit } from '@angular/core';
import { Order } from '../shared/models/Order';
import { OrderService } from '../services/order/order.service';

@Component({
  selector: 'app-order-page',
  templateUrl: './order-page.component.html',
  styleUrl: './order-page.component.css',
})
export class OrderPageComponent implements OnInit {
  orders: Order[] | undefined;

  constructor(private orderService: OrderService) {}

  ngOnInit(): void {
    this.orderService.getAllOrders().subscribe((response) => {
      this.orders = response;
    });
  }

  invalidateOrderLog(order: Order) {}
}
