import { Injectable } from '@angular/core';
import { CarPart } from '../../shared/models/CarPart';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../../../environment';
import { createUrl } from '../../shared/util/url-helper';
import { PagedList } from '../../shared/models/PagedList';
import CarPartFilter from '../../shared/models/CarPartFilter';

export interface ICarPartService {
  getAllCarPartsWithPagination(
    page: number,
    pageSize: number,
    searchTerm?: string,
    carPartfilter?: CarPartFilter
  ): Observable<PagedList<CarPart>>;
  getCarPartById(carPartId: number): Observable<CarPart>;
  getAllCarParts(): Observable<CarPart[]>;
  createCarPart(selectedCarPart: CarPart): Observable<CarPart>;
  deleteCarPart(carPartId: number): Observable<void>;
}

@Injectable({
  providedIn: 'root',
})
export class CarPartService implements ICarPartService {
  private baseApiUrl = environment.baseApiUrl;
  private readonly carPartPath = 'car-parts';

  constructor(private http: HttpClient) {}

  public getAllCarParts(): Observable<CarPart[]> {
    const url = createUrl(
      this.baseApiUrl,
      this.carPartPath,
      'without-pagination'
    );
    return this.http.get<CarPart[]>(url);
  }

  public getAllCarPartsWithPagination(
    page: number,
    pageSize: number,
    searchTerm?: string,
    carPartFilter?: CarPartFilter
  ): Observable<PagedList<CarPart>> {
    const url = createUrl(this.baseApiUrl, this.carPartPath);
    let params = new HttpParams()
      .set('page', page.toString())
      .set('pageSize', pageSize.toString())
      .set('searchTerm', searchTerm ?? '')
      .set('selectedCarBrandId', carPartFilter?.selectedCarBrandId ?? '')
      .set(
        'selectedGenericCarModelId',
        carPartFilter?.selectedGenericCarModelId ?? ''
      );
    return this.http.get<PagedList<CarPart>>(url, {
      params,
    });
  }

  public getCarPartById(carPartId: number): Observable<CarPart> {
    const url = createUrl(
      this.baseApiUrl,
      this.carPartPath,
      carPartId.toString()
    );
    return this.http.get<CarPart>(url);
  }

  createCarPart(selectedCarPart: CarPart): Observable<CarPart> {
    const url = createUrl(this.baseApiUrl, this.carPartPath);
    return this.http.post<CarPart>(url, selectedCarPart);
  }

  updateCarPart(selectedCarPart: CarPart): Observable<CarPart> {
    const url = createUrl(this.baseApiUrl, this.carPartPath);
    return this.http.put<CarPart>(url, selectedCarPart);
  }

  deleteCarPart(carPartId: number): Observable<void> {
    const url = createUrl(
      this.baseApiUrl,
      this.carPartPath,
      carPartId.toString()
    );
    return this.http.delete<void>(url);
  }
}
