import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environment';
import { HttpClient } from '@angular/common/http';
import { createUrl } from '../../shared/util/url-helper';
import { Customer } from '../../shared/models/Customer';

export interface ICustomerService {
  getAllCustomers(): Observable<Customer[]>;
}

@Injectable({
  providedIn: 'root',
})
export class CustomerService implements ICustomerService {
  private baseApiUrl = environment.baseApiUrl;
  private readonly customerPath = 'customers';

  constructor(private http: HttpClient) {}

  public getAllCustomers(): Observable<Customer[]> {
    const url = createUrl(this.baseApiUrl, this.customerPath);
    return this.http.get<Customer[]>(url);
  }
}
