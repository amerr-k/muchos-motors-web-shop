import { Component, OnInit } from '@angular/core';
import { InventoryLogService } from '../services/inventory-log/inventory-log.service';
import { InventoryLog } from '../shared/models/InventoryLog';
import { ActivatedRoute, Router } from '@angular/router';
import { CarPart } from '../shared/models/CarPart';
import { CarPartService } from '../services/car-part/car-part.service';
import { PagedList } from '../shared/models/PagedList';
import { InventoryCarPartLog } from '../shared/models/InventoryCarPartLog';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-inventory-details-page',
  templateUrl: './inventory-details-page.component.html',
  styleUrl: './inventory-details-page.component.css',
})
export class InventoryDetailsPageComponent implements OnInit {
  newInventoryCarPart: InventoryCarPartLog;
  inventoryLog: InventoryLog;
  carParts: CarPart[] | undefined;
  pagedList: PagedList<CarPart> | undefined;

  constructor(
    private inventoryLogService: InventoryLogService,
    private carPartService: CarPartService,
    private toastr: ToastrService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.inventoryLog = new InventoryLog();
    this.newInventoryCarPart = new InventoryCarPartLog();
  }

  ngOnInit(): void {
    this.carPartService.getAllCarParts().subscribe((response) => {
      this.carParts = response;
    });
    this.route.params.subscribe((params) => {
      console.log(params['id']);
      if (params['id'] != '0' && params['id']) {
        this.inventoryLogService
          .getInventoryLogById(params['id'])
          .subscribe((response) => {
            this.inventoryLog = response;
          });
      }
    });
  }

  createInventoryLog() {
    this.inventoryLogService
      .createInventoryLog(this.inventoryLog)
      .subscribe((response) => {
        this.router.navigate(['/inventory-page']);
        this.toastr.success('Uspješno ste kreirali evidenciju inventure');
      });
  }

  createNewInventoryCarPartLog() {
    if (this.newInventoryCarPart) {
      if (!this.inventoryLog.inventoryCarPartLogs) {
        this.inventoryLog.inventoryCarPartLogs = [];
      }
      let carPart = this.carParts?.find(
        (x) => x.carPartId == this.newInventoryCarPart.carPartId
      );
      this.newInventoryCarPart.carPart = carPart;
      this.inventoryLog.inventoryCarPartLogs?.push(this.newInventoryCarPart);
      this.newInventoryCarPart = {};
    }
  }
}
