namespace CarShop.Data.Models
{

    using System.Collections.Generic;

    using CarShop.Data.Common.Models;

    public class CarModel : BaseDeletableModel<int>
    {
        public CarModel()
        {
              this.CarBrands = new List<CarBrand>();
        }

        public string ModelName { get; set; }

        public ICollection<CarBrand> CarBrands { get; set; }
    }
}
