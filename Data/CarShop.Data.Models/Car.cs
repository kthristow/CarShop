namespace CarShop.Data.Models
{
    using System.Collections.Generic;

    using CarShop.Data.Common.Models;

    public class Car : BaseDeletableModel<int>
    {

        public Car()
        {
            this.Images = new List<Image>();
        }

        public int YearOfCreation { get; set; }

        public int Mileage { get; set; }

        public int HorsePower { get; set; }

        public string Color { get; set; }

        public int TransmissionId { get; set; }

        public virtual Transmission Transmission { get; set; }

        public int EngineTypeId { get; set; }

        public virtual EngineType EngineType { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int CarModelId { get; set; }

        public virtual CarModel CarModel { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
