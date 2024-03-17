import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environment';
import { HttpClient } from '@angular/common/http';
import { createUrl } from '../../shared/util/url-helper';
import { CarBrand } from '../../shared/models/CarBrand';

export interface ICarBrandService {
  getAllCarBrands(): Observable<CarBrand[]>;
}

@Injectable({
  providedIn: 'root',
})
export class CarBrandService implements ICarBrandService {
  private baseApiUrl = environment.baseApiUrl;
  private readonly carBrandPath = 'car-brands';

  constructor(private http: HttpClient) {}

  public getAllCarBrands(): Observable<CarBrand[]> {
    const url = createUrl(this.baseApiUrl, this.carBrandPath);
    return this.http.get<CarBrand[]>(url);
  }
}
