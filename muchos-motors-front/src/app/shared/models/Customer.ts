import { City } from './City';

export class Customer {
  customerId: number | undefined;
  firstName: string | undefined;
  lastName: string | undefined;
  email: string | undefined;
  username: string | undefined;
  password: string | undefined;
  repeatedPassword: string | undefined;
  phone: string | undefined;
  address: string | undefined;
  note: string | undefined;
  cityId: number | undefined;
  city: City | undefined;
  isValid: boolean | undefined;
}
