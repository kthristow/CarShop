namespace CarShop.Services.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Web.ViewModels.Car;
    using Microsoft.AspNetCore.Hosting;

    public class CarService : ICarService
    {
        private readonly ApplicationDbContext dbContext;

        public CarService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public AddNewCarViewModel GetNewCarViewModel()
        {
            var vm = new AddNewCarViewModel()
            {
                CarBrands = this.GetBrands(),
                Category = this.GetCatergories(),
                Transmission = this.GetTransmissions(),
                EngineType = this.GetEngineTypes(),
            };
            return vm;
        }

        public Dictionary<string, string> GetBrands()
        {
            return this.dbContext.CarBrands
                .ToDictionary(x => x.Id.ToString(), y => y.BrandName);
        }

        public Dictionary<string, string> GetModels(int brandId)
        {
            return this.dbContext.CarModels.Where(x => x.CarBrand.Id == brandId)
                .ToDictionary(x => x.Id.ToString(), y => y.ModelName);
        }

        public Dictionary<string, string> GetCatergories()
        {
            return this.dbContext.Categories
                .ToDictionary(x => x.Id.ToString(), y => y.Name);
        }

        public Dictionary<string, string> GetTransmissions()
        {
            return this.dbContext.Transmissions
                .ToDictionary(x => x.Id.ToString(), y => y.Name);
        }

        public Dictionary<string, string> GetEngineTypes()
        {
            return this.dbContext.EngineTypes
                .ToDictionary(x => x.Id.ToString(), y => y.Name);
        }

        public void SaveNewCar(AddNewCarViewModel viewModel, string userId, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}/cars/");
            var dbModel = new Car()
            {
                CarModelId = viewModel.CarModelId,
                CategoryId = viewModel.CategoryId,
                Color = viewModel.Color,
                EngineTypeId = viewModel.EngineTypeId,
                HorsePower = viewModel.HoursePower,
                Mileage = viewModel.Mileage,
                TransmissionId = viewModel.TransmissionId,
                YearOfCreation = viewModel.YearOfCreation,
                AddedByUserId = userId,
            };

            foreach (var image in viewModel.Images)
            {
                var extension = Path.GetExtension(image.FileName);
                var dbImage = new Image()
                { 
                    AddedByUserId = userId,
                    Extension = extension,
                };

                dbModel.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/cars/{dbImage.Id}{extension}";
                using (Stream filestream = new FileStream(physicalPath, FileMode.Create))
                {
                    image.CopyTo(filestream);
                }
            }

            this.dbContext.Add(dbModel);
            this.dbContext.SaveChanges();
        }

        public DetailsCarViewModel GetCarById(int id)
        {
            var vm = this.dbContext.Cars.Where(x => x.Id == id)
                .Select(x => new DetailsCarViewModel
                {
                    Brand = x.CarModel.CarBrand.BrandName,
                    Model = x.CarModel.ModelName,
                    Category = x.Category.Name,
                    Color = x.Color,
                    EngineType = x.EngineType.Name,
                    HoursePower = x.HorsePower,
                    Mileage = x.Mileage,
                    YearOfCreation = x.YearOfCreation,
                    Transmission = x.Transmission.Name,
                }).FirstOrDefault();

            return vm;
        }
    }
}
