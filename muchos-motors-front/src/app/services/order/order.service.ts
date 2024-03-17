import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environment';
import { HttpClient } from '@angular/common/http';
import { createUrl } from '../../shared/util/url-helper';
import { Order } from '../../shared/models/Order';

export interface IOrderService {
  getAllOrders(): Observable<Order[]>;
  createOrder(order: Order): Observable<any>;
}

@Injectable({
  providedIn: 'root',
})
export class OrderService implements IOrderService {
  private baseApiUrl = environment.baseApiUrl;
  private readonly orderPath = 'orders';

  constructor(private http: HttpClient) {}

  public getAllOrders(): Observable<Order[]> {
    const url = createUrl(this.baseApiUrl, this.orderPath);
    return this.http.get<Order[]>(url);
  }

  public createOrder(order: Order): Observable<any> {
    const url = createUrl(this.baseApiUrl, this.orderPath);
    return this.http.post<any>(url, order);
  }

  public getOrderById(orderId: number) {
    const url = createUrl(this.baseApiUrl, this.orderPath, orderId.toString());
    return this.http.get<Order>(url);
  }

  public updateOrder(order: Order) {
    const url = createUrl(this.baseApiUrl, this.orderPath);
    return this.http.put<Order>(url, order);
  }
}
