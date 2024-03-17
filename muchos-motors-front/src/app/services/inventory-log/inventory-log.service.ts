import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { createUrl } from '../../shared/util/url-helper';
import { Customer } from '../../shared/models/Customer';
import { InventoryLogEndpoint } from '../../endpoints/inventory-log-endpoint';
import { ToastrService } from 'ngx-toastr';
import { InventoryLog } from '../../shared/models/InventoryLog';

export interface IInventoryLogService {
  getAllInventoryLogs(): Observable<InventoryLog[]>;
  getInventoryLogById(inventoryLogId: number): Observable<InventoryLog>;
  createInventoryLog(inventoryLog: InventoryLog): Observable<any>;
}

@Injectable({
  providedIn: 'root',
})
export class InventoryLogService implements IInventoryLogService {
  constructor(
    private inventoryLogEndpoint: InventoryLogEndpoint,
    private toastr: ToastrService
  ) {}

  getAllInventoryLogs(): Observable<InventoryLog[]> {
    return this.inventoryLogEndpoint.getAllInventoryLogs();
  }

  createInventoryLog(inventoryLog: InventoryLog): Observable<any> {
    return this.inventoryLogEndpoint.createInventoryLog(inventoryLog);
  }

  getInventoryLogById(inventoryLogId: number) {
    return this.inventoryLogEndpoint.getInventoryLogById(inventoryLogId);
  }
}
