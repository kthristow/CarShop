namespace CarShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CarShop.Data;
    using CarShop.Web.ViewModels.Home;

    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext dbContext;

        public DashboardService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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
                    RemoteUrl = x.Images.FirstOrDefault().RemoteUrl,
                }).ToList();
        }

        public int GetCount()
        {
            return this.dbContext.Cars.Count();
        }
    }
}
