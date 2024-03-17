import { Component, OnInit } from '@angular/core';
import { CartService } from '../services/cart/cart.service';
import { Cart } from '../shared/models/Cart';
import { OrderItem } from '../shared/models/OrderItem';
import { environment } from '../../../environment';

@Component({
  selector: 'app-cart-page',
  templateUrl: './cart-page.component.html',
  styleUrl: './cart-page.component.css',
})
export class CartPageComponent implements OnInit {
  cart!: Cart;
  baseUrl: string = environment.baseApiUrl;

  constructor(private cartService: CartService) {
    this.setCart();
  }

  ngOnInit(): void {}

  removeFromCart(orderItem: OrderItem) {
    this.cartService.removeFromCart(orderItem.carPart.carPartId);
    this.setCart();
  }

  changeQuantity(orderItem: OrderItem, quantityString: string) {
    const quantity = parseInt(quantityString);
    this.cartService.changeQuantity(orderItem.carPart.carPartId, quantity);
    this.setCart();
  }

  setCart() {
    this.cart = this.cartService.getCart();
  }
}
