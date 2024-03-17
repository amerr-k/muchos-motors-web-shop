import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { environment } from '../../../environment';
import { HttpClient } from '@angular/common/http';
import { createUrl } from '../shared/util/url-helper';
import { InventoryLog } from '../shared/models/InventoryLog';

export interface IInventoryLogEndpoint {
  getAllInventoryLogs(): Observable<InventoryLog[]>;
  createInventoryLog(inventoryLog: InventoryLog): Observable<any>;
}

@Injectable({
  providedIn: 'root',
})
export class InventoryLogEndpoint implements IInventoryLogEndpoint {
  private baseApiUrl = environment.baseApiUrl;
  private readonly inventoryLogPath = 'inventory-log';

  constructor(private http: HttpClient) {}

  public getAllInventoryLogs(): Observable<InventoryLog[]> {
    const url = createUrl(this.baseApiUrl, this.inventoryLogPath);
    return this.http.get<InventoryLog[]>(url);
  }

  public createInventoryLog(inventoryLog: InventoryLog) {
    const url = createUrl(this.baseApiUrl, this.inventoryLogPath);
    return this.http.post(url, inventoryLog);
  }

  getInventoryLogById(inventoryLogId: number) {
    const url = createUrl(
      this.baseApiUrl,
      this.inventoryLogPath,
      inventoryLogId.toString()
    );
    return this.http.get<InventoryLog>(url);
  }
}
