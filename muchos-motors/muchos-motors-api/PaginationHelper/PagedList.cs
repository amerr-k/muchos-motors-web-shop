using System;
using System.Collections;

namespace muchos_motors_api.PaginationHelper
{
    public class PagedList
    {
        public IEnumerable ItemList { get; private set; }
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }

        public PagedList()
        {

        }

        public PagedList(IEnumerable itemList, int totalItems, int page, int pageSize = 10)
        {
            //ValidateParameters(itemList, totalItems, page, pageSize);

            CurrentPage = page;
            PageSize = pageSize;
            TotalItems = totalItems;
            TotalPages = CalculateTotalPages(totalItems, pageSize);

            CalculateStartAndEndPages();

            ItemList = itemList;
        }

        //private void ValidateParameters(IEnumerable itemList, int totalItems, int page, int pageSize)
        //{
        //    if (page <= 0 || page > CalculateTotalPages(totalItems, pageSize))
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(page), "Invalid page number.");
        //    }
        //}

        private int CalculateTotalPages(int totalItems, int pageSize)
        {
            return (int)Math.Ceiling((decimal)totalItems / pageSize);
        }

        private void CalculateStartAndEndPages()
        {
            var totalPages = TotalPages;

            StartPage = Math.Max(1, CurrentPage - 5);
            EndPage = Math.Min(totalPages, CurrentPage + 4);

            if (EndPage - StartPage < 9)
            {
                StartPage = Math.Max(1, EndPage - 9);
            }
        }

        public override string ToString()
        {
            return $"PagedList: CurrentPage={CurrentPage}, PageSize={PageSize}, TotalItems={TotalItems}, TotalPages={TotalPages}";
        }
    }
}
