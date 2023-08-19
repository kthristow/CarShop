using System;

namespace CarShop.Web.ViewModels.Car
{
    public class DetailsCarViewModel
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Category { get; set; }

        public int Mileage { get; set; }

        public string EngineType { get; set; }

        public string Transmission { get; set; }

        public int HoursePower { get; set; }

        public string Color { get; set; }

        public int YearOfCreation { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }
    }
}
