namespace CarShop.Web.Controllers
{
    using System.Diagnostics;

    using CarShop.Services.Data;
    using CarShop.Web.ViewModels;
    using CarShop.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IDashboardService dashboardService;

        public HomeController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }

        public IActionResult Index(int id = 1)
        {
            var vm = new CarsViewModel()
            {
                PageNumber = id,
                Cars = this.dashboardService.GetLastUploadedCars(id, 12),
            };
            return this.View(vm);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
