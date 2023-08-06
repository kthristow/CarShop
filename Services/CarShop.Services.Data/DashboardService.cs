namespace CarShop.Services.Data
{
    using CarShop.Data;

    using CarShop.Web.ViewModels.Home;
    using System.Collections.Generic;
    using System.Linq;

    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext dbContext;

        public DashboardService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<HomeVM> GetLastUploadedCars()
        {
            return this.dbContext.Cars
                .Select(x => new HomeVM
                {
                    CarModel = x.CarModel.ModelName,
                    CarBrand = x.CarModel.CarBrand.BrandName,
                    CategoryName = x.Category.Name,
                    HorsePower = x.HorsePower,
                    Mileage = x.Mileage,
                    YearOfCreation = x.YearOfCreation,
                    RemoteUrl = x.Images.FirstOrDefault().RemoteUrl,
                }).ToList();
        }
    }
}
