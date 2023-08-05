namespace CarShop.Data.Models
{

    using System.Collections.Generic;

    using CarShop.Data.Common.Models;

    public class CarModel : BaseDeletableModel<int>
    {

        public string ModelName { get; set; }

        public int CarBrandId { get; set; }

        public CarBrand CarBrand { get; set; }
    }
}
