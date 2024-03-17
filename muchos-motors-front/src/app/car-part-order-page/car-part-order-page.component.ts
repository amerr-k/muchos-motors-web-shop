import { CarPart } from '../shared/models/CarPart';
import { CarPartService } from '../services/car-part/car-part.service';
import { CartService } from '../services/cart/cart.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environment';

@Component({
  selector: 'app-car-part-page',
  templateUrl: './car-part-order-page.component.html',
  styleUrl: './car-part-order-page.component.css',
})
export class CarPartOrderPageComponent implements OnInit {
  carPart!: CarPart;
  baseUrl: string = environment.baseApiUrl;

  constructor(
    private activatedRoute: ActivatedRoute,
    private carPartService: CarPartService,
    private cartService: CartService,
    private router: Router
  ) {
    activatedRoute.params.subscribe((params) => {
      if (params['id']) {
        this.carPartService
          .getCarPartById(params['id'])
          .subscribe((response) => {
            this.carPart = response;
          });
      }
    });
  }

  ngOnInit(): void {}

  addToCart() {
    this.cartService.addToCart(this.carPart);
    this.router.navigateByUrl('/cart-page');
  }
}
