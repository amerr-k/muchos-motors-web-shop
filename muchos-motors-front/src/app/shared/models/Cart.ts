import { OrderItem } from './OrderItem';

export class Cart {
  items: OrderItem[] = [];

  get totalPrice(): number {
    let totalPrice = 0;
    this.items.forEach((item) => {
      totalPrice += item.calculatePrice();
    });
    return totalPrice;
  }
}
