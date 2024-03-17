import { City } from './City';
import { Customer } from './Customer';
import { OrderItem } from './OrderItem';

export class Order {
  orderId: number | undefined;
  customerId: number | undefined;
  customer: Customer | undefined;
  customerFirstName: string | undefined;
  customerLastName: string | undefined;
  customerShippingAddress: string | undefined;
  customerEmail: string | undefined;
  customerPhone: string | undefined;
  customerShippingCityId: string | undefined;
  customerShippingCity: City | undefined;
  employeeId: number | undefined;
  orderDate: Date | undefined;
  shippingDate: Date | undefined;
  totalPrice: number | undefined;
  invoiceCreated: boolean | undefined;
  orderItems: OrderItem[] | undefined;
  isValid: boolean | undefined;
}
