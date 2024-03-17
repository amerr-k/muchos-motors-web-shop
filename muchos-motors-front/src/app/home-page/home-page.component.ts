import { Component, OnInit } from '@angular/core';
import { CarPartService } from '../services/car-part/car-part.service';
import { CarPart } from '../shared/models/CarPart';
import { PageEvent } from '@angular/material/paginator';
import { PagedList } from '../shared/models/PagedList';
import { ActivatedRoute } from '@angular/router';
import { CarBrandService } from '../services/car-brand/car-brand.service';
import { CarBrand } from '../shared/models/CarBrand';
import GenericCarModel from '../shared/models/GenericCarModel';
import { GenericCarModelService } from '../services/generic-car-model/generic-car-model.service';
import CarPartFilter from '../shared/models/CarPartFilter';
import { DEFAULT_CURRENT_PAGE, DEFAULT_PAGE_SIZE } from '../constants';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css',
})
export class HomePageComponent implements OnInit {
  pagedList: PagedList<CarPart> | undefined;
  carBrands: CarBrand[] | undefined;
  genericCarModels: GenericCarModel[] | undefined;

  constructor(
    private carPartService: CarPartService,
    private route: ActivatedRoute,
    private carBrandService: CarBrandService,
    private genericCarModelService: GenericCarModelService,
    private toastr: ToastrService,
    public authService: AuthService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      if (params['searchTerm']) {
        this.carPartService
          .getAllCarPartsWithPagination(
            DEFAULT_CURRENT_PAGE,
            DEFAULT_PAGE_SIZE,
            params['searchTerm']
          )
          .subscribe((response) => {
            this.pagedList = response;
          });
      } else {
        this.carPartService
          .getAllCarPartsWithPagination(DEFAULT_CURRENT_PAGE, DEFAULT_PAGE_SIZE)
          .subscribe((response) => {
            this.pagedList = response;
          });
      }
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

  handleSearchCarPartsWithFilter(carPartfilter: CarPartFilter) {
    this.carPartService
      .getAllCarPartsWithPagination(
        DEFAULT_CURRENT_PAGE,
        DEFAULT_PAGE_SIZE,
        undefined,
        carPartfilter
      )
      .subscribe((response) => {
        this.pagedList = response;
      });
  }
}
