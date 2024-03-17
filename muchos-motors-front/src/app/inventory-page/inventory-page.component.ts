import { Component, OnInit } from '@angular/core';
import { InventoryLog } from '../shared/models/InventoryLog';
import { InventoryLogService } from '../services/inventory-log/inventory-log.service';

@Component({
  selector: 'app-inventory-page',
  templateUrl: './inventory-page.component.html',
  styleUrl: './inventory-page.component.css',
})
export class InventoryPageComponent implements OnInit {
  inventoryLogs: InventoryLog[] | undefined;

  constructor(private inventoryLogService: InventoryLogService) {}

  ngOnInit(): void {
    this.inventoryLogService.getAllInventoryLogs().subscribe((response) => {
      this.inventoryLogs = response;
    });
  }

  invalidateInventoryLog(inventoryLog: InventoryLog) {}
}
