namespace CarShop.Web.Controllers
{
    using CarShop.Services.Data;
    using CarShop.Web.ViewModels.Home;

    using Microsoft.AspNetCore.Mvc;

    public class CarController : BaseController
    {
        private readonly IDashboardService dashboardService;

        public CarController(IDashboardService dashboardService)
        {
           this.dashboardService = dashboardService;
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 12;
            var vm = new CarsViewModel()
            {
                PageNumber = id,
                ItemsPerPage = ItemsPerPage,
                CarsCount = this.dashboardService.GetCount(),
                Cars = this.dashboardService.GetLastUploadedCars(id, ItemsPerPage),
            };
            return this.View(vm);
        }

        public IActionResult AddNewCar()
        {
            return this.View();
        }
    }
}
