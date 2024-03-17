import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { CarPartOrderPageComponent } from './car-part-order-page/car-part-order-page.component';
import { CartPageComponent } from './cart-page/cart-page.component';
import { CheckoutPageComponent } from './checkout-page/checkout-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { OrderPageComponent } from './order-page/order-page.component';
import { CarPartPageComponent } from './car-part-page/car-part-page.component';
import { InventoryPageComponent } from './inventory-page/inventory-page.component';
import { RegistrationPageComponent } from './registration-page/registration-page.component';
import { InventoryDetailsPageComponent } from './inventory-details-page/inventory-details-page.component';
import { CustomerMethodsGuard } from './shared/util/auth/customer-methods-guard';
import { EmployeeMethodsGuard } from './shared/util/auth/employee-methods-guard';
import { OrderDetailsPageComponent } from './order-details-page/order-details-page.component';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'search/:searchTerm', component: HomePageComponent },
  {
    path: 'car-part-order-page/:id',
    component: CarPartOrderPageComponent,
  },
  {
    path: 'cart-page',
    component: CartPageComponent,
  },
  {
    path: 'checkout-page',
    component: CheckoutPageComponent,
  },
  { path: 'login-page', component: LoginPageComponent },
  { path: 'registration-page', component: RegistrationPageComponent },
  {
    path: 'order-page',
    component: OrderPageComponent,
    canActivate: [EmployeeMethodsGuard],
  },
  {
    path: 'car-part-page',
    component: CarPartPageComponent,
    canActivate: [EmployeeMethodsGuard],
  },
  {
    path: 'inventory-page',
    component: InventoryPageComponent,
    canActivate: [EmployeeMethodsGuard],
  },
  {
    path: 'inventory-details-page/:id',
    component: InventoryDetailsPageComponent,
    canActivate: [EmployeeMethodsGuard],
  },
  {
    path: 'order-details-page/:id',
    component: OrderDetailsPageComponent,
    canActivate: [EmployeeMethodsGuard],
  },
  {
    path: 'order-page/:id',
    component: OrderPageComponent,
    canActivate: [EmployeeMethodsGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
