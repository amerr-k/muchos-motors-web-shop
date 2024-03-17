import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CarBrand } from '../../shared/models/CarBrand';
import GenericCarModel from '../../shared/models/GenericCarModel';
import { CarBrandService } from '../../services/car-brand/car-brand.service';
import { GenericCarModelService } from '../../services/generic-car-model/generic-car-model.service';
import CarPartFilter from '../../shared/models/CarPartFilter';

@Component({
  selector: 'app-filter-card',
  templateUrl: './filter-card.component.html',
  styleUrl: './filter-card.component.css',
})
export class FilterCardComponent implements OnInit {
  carBrands: CarBrand[] | undefined;
  genericCarModels: GenericCarModel[] | undefined;
  selectedCarBrandId: string | undefined;
  selectedGenericCarModelId: string | undefined;

  constructor(
    private carBrandService: CarBrandService,
    private genericCarModelService: GenericCarModelService
  ) {}

  ngOnInit(): void {
    this.carBrandService.getAllCarBrands().subscribe((response) => {
      this.carBrands = response;
    });

    this.genericCarModelService
      .getAllGenericCarModels()
      .subscribe((response) => {
        this.genericCarModels = response;
      });
  }

  @Output()
  onSearchCarPartsWithFilter: EventEmitter<any> = new EventEmitter<any>();

  searchCarPartsWithFilter() {
    const filter: CarPartFilter = {
      selectedCarBrandId: this.selectedCarBrandId,
      selectedGenericCarModelId: this.selectedGenericCarModelId,
    };
    this.onSearchCarPartsWithFilter.emit(filter);
  }
}
