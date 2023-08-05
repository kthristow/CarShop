namespace CarShop.Data.Models
{

    using System.Collections.Generic;

    using CarShop.Data.Common.Models;

    public class CarBrand : BaseDeletableModel<int>
    {
        public CarBrand()
        {
              this.CarModels = new List<CarModel>();
        }

        public string BrandName { get; set; }

        public ICollection<CarModel> CarModels { get; set; }
    }
}
