namespace CarShop.Web.ViewModels.Car
{
    using System.Collections.Generic;

    using CarShop.Data.Models;
    using Microsoft.AspNetCore.Http;

    public class AddNewCarViewModel
    {
        public Dictionary<string, string> CarBrands { get; set; }

        public int CarBrandId { get; set; }

        public Dictionary<string, string> CarModels { get; set; }

        public int CarModelId { get; set; }

        public Dictionary<string, string> Category { get; set; }

        public int CategoryId { get; set; }

        public int YearOfCreation { get; set; }

        public int Mileage { get; set; }

        public int HoursePower { get; set; }

        public string Color { get; set; }

        public Dictionary<string, string> Transmission { get; set; }

        public int TransmissionId { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

        public Dictionary<string, string> EngineType { get; set; }

        public int EngineTypeId { get; set; }
    }
}
