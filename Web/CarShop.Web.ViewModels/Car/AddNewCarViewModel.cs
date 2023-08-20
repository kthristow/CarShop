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

        [Range(1, int.MaxValue,ErrorMessage = "Brand is Required")]
        public int? CarBrandId { get; set; }

        [Required]
        public Dictionary<string, string> CarModels { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Model is Required")]
        public int? CarModelId { get; set; }

        [Required]
        public Dictionary<string, string> Category { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Category is Required")]
        public int? CategoryId { get; set; }

        [Required]
        public int? YearOfCreation { get; set; }

        [Required]
        public int? Mileage { get; set; }

        [Required]
        public int? HoursePower { get; set; }


        public string Color { get; set; }

        [Required]
        public Dictionary<string, string> Transmission { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Transmission is Required")]
        public int? TransmissionId { get; set; }

        [Required]
        public IFormFile Images { get; set; }

        [Required]
        public Dictionary<string, string> EngineType { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Engine Type is Required")]
        public int? EngineTypeId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
