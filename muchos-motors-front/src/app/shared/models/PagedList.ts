export class PagedList<T> {
  itemList: T[];
  totalItems: number;
  currentPage: number;
  pageSize: number;
  totalPages: number;
  startPage: number;
  endPage: number;

  constructor(
    itemList: T[],
    totalItems: number,
    currentPage: number,
    pageSize: number,
    totalPages: number,
    startPage: number,
    endPage: number
  ) {
    this.itemList = itemList;
    this.totalItems = totalItems;
    this.currentPage = currentPage;
    this.pageSize = pageSize;
    this.totalPages = totalPages;
    this.startPage = startPage;
    this.endPage = endPage;
  }
}
