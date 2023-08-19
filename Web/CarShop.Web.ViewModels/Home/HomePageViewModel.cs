using System.Collections.Generic;

namespace CarShop.Web.ViewModels.Home
{
    public class HomePageViewModel
    {
        public int CarsCount { get; set; }

        public int CategoryCount { get; set; }

        public int BrandsCount { get; set; }

        public int ModelsCount { get; set; }

        public IEnumerable<CarViewModel> Cars { get; set; }
    }
}
