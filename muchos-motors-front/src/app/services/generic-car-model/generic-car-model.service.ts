import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environment';
import { HttpClient } from '@angular/common/http';
import { createUrl } from '../../shared/util/url-helper';
import GenericCarModel from '../../shared/models/GenericCarModel';

export interface IGenericCarModelService {
  getAllGenericCarModels(): Observable<GenericCarModel[]>;
}

@Injectable({
  providedIn: 'root',
})
export class GenericCarModelService implements IGenericCarModelService {
  private baseApiUrl = environment.baseApiUrl;
  private readonly genericCarModelPath = 'generic-car-models';

  constructor(private http: HttpClient) {}

  public getAllGenericCarModels(): Observable<GenericCarModel[]> {
    const url = createUrl(this.baseApiUrl, this.genericCarModelPath);
    return this.http.get<GenericCarModel[]>(url);
  }
}
