import { Injectable } from '@angular/core';
import { Cart } from '../../shared/models/Cart';
import { CarPart } from '../../shared/models/CarPart';
import { OrderItem } from '../../shared/models/OrderItem';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private cart: Cart = new Cart();

  addToCart(carPart: CarPart): void {
    let orderItem = this.cart.items.find(
      (item) => item.carPart.carPartId == carPart.carPartId
    );
    if (orderItem) {
      this.changeQuantity(carPart.carPartId, orderItem.quantity + 1);
      return;
    }

    this.cart.items.push(new OrderItem(carPart));
  }

  removeFromCart(carPartId: number): void {
    this.cart.items = this.cart.items.filter(
      (item) => item.carPart.carPartId != carPartId
    );
  }

  changeQuantity(carPartId: number, quantity: number) {
    let orderItem = this.cart.items.find(
      (item) => item.carPart.carPartId == carPartId
    );
    if (!orderItem) return;
    orderItem.quantity = quantity;
  }

  getCart(): Cart {
    return this.cart;
  }
}
