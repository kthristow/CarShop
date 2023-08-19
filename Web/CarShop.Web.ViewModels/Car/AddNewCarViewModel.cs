namespace CarShop.Web.ViewModels.Car
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CarShop.Data.Models;
    using Microsoft.AspNetCore.Http;

    public class AddNewCarViewModel
    {
        public int CarId { get; set; }

        [Required]
        public Dictionary<string, string> CarBrands { get; set; }

        [Required]
        public int CarBrandId { get; set; }

        [Required]
        public Dictionary<string, string> CarModels { get; set; }

        [Required]
        public int CarModelId { get; set; }

        [Required]
        public Dictionary<string, string> Category { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int YearOfCreation { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public int HoursePower { get; set; }


        public string Color { get; set; }

        [Required]
        public Dictionary<string, string> Transmission { get; set; }

        [Required]
        public int TransmissionId { get; set; }

        [Required]
        public IFormFile Images { get; set; }

        [Required]
        public Dictionary<string, string> EngineType { get; set; }

        [Required]
        public int EngineTypeId { get; set; }

        public string Description { get; set; }
    }
}
