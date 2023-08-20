namespace CarShop.Services.Data
{
    using System;
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
                CarModelId = viewModel.CarModelId.Value,
                CategoryId = viewModel.CategoryId.Value,
                Color = viewModel.Color,
                EngineTypeId = viewModel.EngineTypeId.Value,
                HorsePower = viewModel.HoursePower.Value,
                Mileage = viewModel.Mileage.Value,
                TransmissionId = viewModel.TransmissionId.Value,
                YearOfCreation = viewModel.YearOfCreation.Value,
                AddedByUserId = userId,
                Description = viewModel.Description,
            };

            var extension = Path.GetExtension(viewModel.Images.FileName).TrimStart('.');
            var dbImage = new Image()
            {
                AddedByUserId = userId,
                Extension = extension,
            };

            dbModel.Image = dbImage;
            dbModel.ImageId = Guid.Parse(dbImage.Id);

            var physicalPath = $"{imagePath}/cars/{dbImage.Id}.{extension}";
            using (Stream filestream = new FileStream(physicalPath, FileMode.Create))
            {
                viewModel.Images.CopyTo(filestream);
            }


            this.dbContext.Add(dbModel);
            this.dbContext.SaveChanges();
        }

        public void UpdateCar(AddNewCarViewModel viewModel)
        {
            var getExistingModel = this.dbContext.Cars.FirstOrDefault(x => x.Id == viewModel.CarId);
            getExistingModel.CarModelId = viewModel.CarModelId.Value;
            getExistingModel.CategoryId = viewModel.CategoryId.Value;
            getExistingModel.Color = viewModel.Color;
            getExistingModel.EngineTypeId = viewModel.EngineTypeId.Value;
            getExistingModel.HorsePower = viewModel.HoursePower.Value;
            getExistingModel.Mileage = viewModel.Mileage.Value;
            getExistingModel.TransmissionId = viewModel.TransmissionId.Value;
            getExistingModel.YearOfCreation = viewModel.YearOfCreation.Value;
            getExistingModel.Description = viewModel.Description;
            this.dbContext.SaveChanges();
        }

        public DetailsCarViewModel GetCarById(int id)
        {
            var vm = this.dbContext.Cars.Where(x => x.Id == id)
                .Select(x => new DetailsCarViewModel
                {
                    Id = x.Id,
                    Brand = x.CarModel.CarBrand.BrandName,
                    Model = x.CarModel.ModelName,
                    Category = x.Category.Name,
                    Color = x.Color,
                    EngineType = x.EngineType.Name,
                    HoursePower = x.HorsePower,
                    Mileage = x.Mileage,
                    YearOfCreation = x.YearOfCreation,
                    Transmission = x.Transmission.Name,
                    ImageUrl = "/images/cars/" + x.Image.Id + "." + x.Image.Extension,
                    Description = x.Description,
                    UserId = x.AddedByUserId,

                }).FirstOrDefault();

            return vm;
        }

        public AddNewCarViewModel GetExistingCarForUpdate(int id)
        {
            var car = this.dbContext.Cars.FirstOrDefault(x => x.Id == id);

            var vm = new AddNewCarViewModel()
            {
                CarBrands = this.GetBrands(),
                Category = this.GetCatergories(),
                Transmission = this.GetTransmissions(),
                EngineType = this.GetEngineTypes(),
                Color = car.Color,
                Description = car.Description,
                CarModelId = car.CarModelId,
                CategoryId = car.CategoryId,
                EngineTypeId = car.EngineTypeId,
                HoursePower = car.HorsePower,
                Mileage = car.Mileage,
                TransmissionId = car.TransmissionId,
                YearOfCreation = car.YearOfCreation,
                CarId = car.Id,
            };
            var carBrand = this.dbContext.CarModels.Where(x => vm.CarModelId == x.Id).FirstOrDefault();

            vm.CarBrandId = carBrand.CarBrandId;
            return vm;
        }

        public void DeleteCar(int id)
        {
            var getCar = this.dbContext.Cars.FirstOrDefault(x => x.Id == id);
            var image = this.dbContext.Image.FirstOrDefault(x => x.Id == getCar.ImageId.ToString());
            this.dbContext.Remove(image);
            this.dbContext.Remove(getCar);
            this.dbContext.SaveChanges();
        }
    }
}
