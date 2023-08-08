namespace CarShop.Web.ViewModels.Home
{
    using System;

    public class PagingViewModel
    {
        public int PageNumber { get; set; }

        public int CarsCount { get; set; }

        public int ItemsPerPage { get; set; }

        public bool HasPreviusPage => this.PageNumber > 1;

        public bool HasNextPage => this.PageNumber < this.PagesCount;

        public int PagesCount => (int)Math.Ceiling((double)this.CarsCount / this.ItemsPerPage);

        public int PreviousPageNumber => this.PageNumber - 1;

        public int NextPageNumber => this.PageNumber + 1;
    }
}