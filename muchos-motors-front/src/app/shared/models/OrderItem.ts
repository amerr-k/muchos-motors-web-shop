import { CarPart } from './CarPart';

export class OrderItem {
  constructor(carPart: CarPart) {
    this.carPart = carPart;
    this.carPartId = carPart.carPartId;
  }

  carPart: CarPart;
  carPartId: number | undefined;
  quantity: number = 1;
  price!: number;

  calculatePrice(): number {
    this.price = this.carPart.sellingPrice * this.quantity;
    return this.price;
  }
}
