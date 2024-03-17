import { NgModule } from '@angular/core';
import { NavigationHeaderComponent } from './navigation-header/navigation-header.component';
import { HomePageComponent } from './home-page/home-page.component';
import { CarPartOrderPageComponent } from './car-part-order-page/car-part-order-page.component';
import { FilterCardComponent } from './home-page/filter-card/filter-card.component';
import { CartPageComponent } from './cart-page/cart-page.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { CheckoutPageComponent } from './checkout-page/checkout-page.component';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { CurrencyPipe } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { MatPaginatorModule } from '@angular/material/paginator';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CarPartGridComponent } from './home-page/car-part-grid/car-part-grid.component';
import { SearchComponent } from './home-page/search/search.component';
import { PaginatorFooterComponent } from './paginator-footer/paginator-footer.component';
import { ToastrModule } from 'ngx-toastr';
import { LoginPageComponent } from './login-page/login-page.component';
import { AuthInterceptor } from './shared/util/auth/auth-interceptor';
import { InventoryPageComponent } from './inventory-page/inventory-page.component';
import { CarPartPageComponent } from './car-part-page/car-part-page.component';
import { OrderPageComponent } from './order-page/order-page.component';
import { RegistrationPageComponent } from './registration-page/registration-page.component';
import { InventoryDetailsPageComponent } from './inventory-details-page/inventory-details-page.component';
import { CustomerMethodsGuard } from './shared/util/auth/customer-methods-guard';
import { EmployeeMethodsGuard } from './shared/util/auth/employee-methods-guard';
import { OrderDetailsPageComponent } from './order-details-page/order-details-page.component';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [
    AppComponent,
    NavigationHeaderComponent,
    HomePageComponent,
    SearchComponent,
    CarPartOrderPageComponent,
    FilterCardComponent,
    CartPageComponent,
    NotFoundComponent,
    CheckoutPageComponent,
    CarPartGridComponent,
    PaginatorFooterComponent,
    LoginPageComponent,
    InventoryPageComponent,
    CarPartPageComponent,
    OrderPageComponent,
    RegistrationPageComponent,
    InventoryDetailsPageComponent,
    OrderDetailsPageComponent,
  ],
  imports: [
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    CurrencyPipe,
    BrowserModule,
    MatPaginatorModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    MatNativeDateModule,
    MatDatepickerModule,
    MatInputModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    CustomerMethodsGuard,
    EmployeeMethodsGuard,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
