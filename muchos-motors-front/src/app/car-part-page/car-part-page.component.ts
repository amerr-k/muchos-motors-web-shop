import { Component, OnInit } from '@angular/core';
import { PagedList } from '../shared/models/PagedList';
import { CarPart } from '../shared/models/CarPart';
import { CarPartService } from '../services/car-part/car-part.service';
import { ActivatedRoute } from '@angular/router';
import { DEFAULT_CURRENT_PAGE, DEFAULT_PAGE_SIZE } from '../constants';
import { PageEvent } from '@angular/material/paginator';
import { AuthService } from '../services/auth/auth.service';
import { ToastrService } from 'ngx-toastr';
import { CarBrandService } from '../services/car-brand/car-brand.service';
import { CarPartCategory } from '../shared/enums/CarPartCategory';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-car-part-page',
  templateUrl: './car-part-page.component.html',
  styleUrl: './car-part-page.component.css',
})
export class CarPartPageComponent implements OnInit {
  pagedList: PagedList<CarPart> | undefined;
  modalVisible: boolean = false;
  selectedCarPart: CarPart | undefined = undefined;
  carPartCategories = Object.keys(CarPartCategory);
  slika_base64_format: string | undefined;

  constructor(
    private carPartService: CarPartService,
    private route: ActivatedRoute,
    private carBrandService: CarBrandService,
    private toastr: ToastrService,
    public authService: AuthService,
    private cdr: ChangeDetectorRef
  ) {
    this.selectedCarPart = new CarPart();
  }

  ngOnInit(): void {
    this.carPartService
      .getAllCarPartsWithPagination(
        this.pagedList?.currentPage ?? DEFAULT_CURRENT_PAGE,
        this.pagedList?.pageSize ?? DEFAULT_PAGE_SIZE
      )
      .subscribe((response) => {
        this.pagedList = response;
        this.selectedCarPart = new CarPart();
      });
  }

  handlePageChange(event: PageEvent): void {
    const page = event.pageIndex + 1;
    const pageSize = event.pageSize;

    this.carPartService
      .getAllCarPartsWithPagination(page, pageSize)
      .subscribe((response) => {
        this.pagedList = response;
      });
  }

  showModal(carPart?: CarPart): void {
    if (carPart) {
      this.selectedCarPart = { ...carPart };
    }
    this.modalVisible = true;
  }

  closeModal(): void {
    this.modalVisible = false;
    this.selectedCarPart = new CarPart();
  }

  updateCarPart(): void {
    this.modalVisible = false;
    if (this.selectedCarPart) {
      this.carPartService.updateCarPart(this.selectedCarPart).subscribe((x) => {
        this.toastr.success('Uspješno ste ažurirali stavku');
        this.selectedCarPart = undefined;
        this.ngOnInit();
      });
    }
  }

  createCarPart(): void {
    this.modalVisible = false;
    if (this.selectedCarPart) {
      this.carPartService.createCarPart(this.selectedCarPart).subscribe((x) => {
        this.toastr.success('Uspješno ste kreirali stavku');
        this.selectedCarPart = undefined;
        this.ngOnInit();
      });
    }
  }

  invalidateInventoryLog(carPartId: number) {
    this.carPartService.deleteCarPart(carPartId).subscribe({
      next: (response: any) => {
        this.toastr.success('Uspješno ste invalidirali stavku');
        this.ngOnInit();
      },
      error: (error: any) => {
        this.toastr.error(error.error.error.details, error.error.error.message);
      },
    });
  }

  generatePreview() {
    // @ts-ignore
    var file = document.getElementById('slika-input').files[0];
    if (file && this.selectedCarPart) {
      var reader = new FileReader();
      reader.onload = () => {
        this.selectedCarPart!.base64Image = reader.result?.toString();
      };
      reader.readAsDataURL(file);
    }
  }
}
