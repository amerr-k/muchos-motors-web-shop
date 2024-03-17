import { Component, Input } from '@angular/core';
import { PagedList } from '../../shared/models/PagedList';
import { CarPart } from '../../shared/models/CarPart';
import { environment } from '../../../../environment';

@Component({
  selector: 'app-car-part-grid',
  templateUrl: './car-part-grid.component.html',
  styleUrl: './car-part-grid.component.css',
})
export class CarPartGridComponent {
  @Input()
  pagedList: PagedList<CarPart> | undefined;
  baseUrl: string = environment.baseApiUrl;

  getImageUrl(carPartId: number): string {
    return `${this.baseUrl}/images/car-part?carPartId=${carPartId}`;
  }
}
