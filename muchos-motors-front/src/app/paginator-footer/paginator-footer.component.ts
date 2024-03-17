import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PagedList } from '../shared/models/PagedList';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-paginator-footer',
  templateUrl: './paginator-footer.component.html',
  styleUrl: './paginator-footer.component.css',
})
export class PaginatorFooterComponent {
  @Input()
  pagedList: PagedList<any> | undefined;

  pageSizeOptions: number[] = [5, 10, 15, 20, 25];

  @Output()
  onPageChange: EventEmitter<PageEvent> = new EventEmitter<PageEvent>();

  changePage(event: PageEvent) {
    this.onPageChange.emit(event);
  }
}
