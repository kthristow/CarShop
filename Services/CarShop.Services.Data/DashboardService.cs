namespace CarShop.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CarShop.Data;
    using CarShop.Web.ViewModels.Administration.Dashboard;
    using CarShop.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Hosting;

    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IHostingEnvironment env;

        public DashboardService(ApplicationDbContext dbContext, IHostingEnvironment env)
        {
            this.dbContext = dbContext;
            this.env = env;
        }

        public List<CarViewModel> GetLastUploadedCars(int page, int itemsPerPage = 12)
        {
            return this.dbContext.Cars
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .Select(x => new CarViewModel
                {
                    CarId = x.Id,
                    CarModel = x.CarModel.ModelName,
                    CarBrand = x.CarModel.CarBrand.BrandName,
                    CategoryName = x.Category.Name,
                    HorsePower = x.HorsePower,
                    Mileage = x.Mileage,
                    YearOfCreation = x.YearOfCreation,
                    ImageUrl = "/images/cars/" + x.Image.Id + "." + x.Image.Extension,
                }).ToList();
        }

        public int GetCount()
        {
            return this.dbContext.Cars.Count();
        }

        public List<CarViewModel> GetMyCars(int page, string userId, int itemsPerPage = 12)
        {
            return this.dbContext.Cars
              .Where(x => x.AddedByUserId == userId)
              .OrderByDescending(x => x.Id)
              .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
              .Select(x => new CarViewModel
              {
                  CarId = x.Id,
                  CarModel = x.CarModel.ModelName,
                  CarBrand = x.CarModel.CarBrand.BrandName,
                  CategoryName = x.Category.Name,
                  HorsePower = x.HorsePower,
                  Mileage = x.Mileage,
                  YearOfCreation = x.YearOfCreation,
                  ImageUrl = "/images/cars/" + x.Image.Id + "." + x.Image.Extension,
              }).ToList();
        }

        public HomePageViewModel GetHomePage(int count)
        {
            var homePage = new HomePageViewModel
            {
                BrandsCount = this.dbContext.CarBrands.Count(),
                CarsCount = this.dbContext.Cars.Count(),
                ModelsCount = this.dbContext.CarModels.Count(),
                CategoryCount = this.dbContext.Categories.Count(),
                Cars = this.GetRandomCars(count),
            };

            return homePage;
        }

        private IEnumerable<CarViewModel> GetRandomCars(int count)
        {
             return this.dbContext.Cars
             .OrderBy(x => Guid.NewGuid())
             .Take(count)
             .Select(x => new CarViewModel
             {
                 CarId = x.Id,
                 CarModel = x.CarModel.ModelName,
                 CarBrand = x.CarModel.CarBrand.BrandName,
                 CategoryName = x.Category.Name,
                 HorsePower = x.HorsePower,
                 Mileage = x.Mileage,
                 YearOfCreation = x.YearOfCreation,
                 ImageUrl = "/images/cars/" + x.Image.Id + "." + x.Image.Extension,
             }).ToList();
        }
    }
}
