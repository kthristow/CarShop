namespace CarShop.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;

    public class CarsViewModel : PagingViewModel
    {

        public List<CarViewModel> Cars { get; set; }

    }
}
