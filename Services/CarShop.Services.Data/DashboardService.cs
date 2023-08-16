namespace CarShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CarShop.Data;
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
                    CarModel = x.CarModel.ModelName,
                    CarBrand = x.CarModel.CarBrand.BrandName,
                    CategoryName = x.Category.Name,
                    HorsePower = x.HorsePower,
                    Mileage = x.Mileage,
                    YearOfCreation = x.YearOfCreation,
                    ImageUrl = $"~/cars/{x.Images.FirstOrDefault().Id}{x.Images.FirstOrDefault().Extension}",
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
                  ImageUrl = $"{this.env.WebRootPath}/cars/{x.Images.FirstOrDefault().Id}{x.Images.FirstOrDefault().Extension}",
              }).ToList();
        }
    }
}
