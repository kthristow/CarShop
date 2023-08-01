namespace CarShop.Data.Models
{
    using CarShop.Data.Common.Models;

    public class CarBrand : BaseDeletableModel<int>
    {
        public string BrandName { get; set; }

        public int CarModelId { get; set; }

        public CarModel CarModel { get; set; }
    }
}
