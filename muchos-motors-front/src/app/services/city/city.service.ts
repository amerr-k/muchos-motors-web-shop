import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environment';
import { HttpClient } from '@angular/common/http';
import { createUrl } from '../../shared/util/url-helper';
import { City } from '../../shared/models/City';

export interface ICityService {
  getAllCities(): Observable<City[]>;
}

@Injectable({
  providedIn: 'root',
})
export class CityService implements ICityService {
  private baseApiUrl = environment.baseApiUrl;
  private readonly cityPath = 'cities';

  constructor(private http: HttpClient) {}

  public getAllCities(): Observable<City[]> {
    const url = createUrl(this.baseApiUrl, this.cityPath);
    return this.http.get<City[]>(url);
  }
}
