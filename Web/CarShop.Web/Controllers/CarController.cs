namespace CarShop.Web.Controllers
{
    using System.IO;
    using System.Security.Claims;

    using CarShop.Data.Models;
    using CarShop.Services.Data;
    using CarShop.Web.ViewModels.Car;
    using CarShop.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CarController : BaseController
    {
        private readonly IDashboardService dashboardService;
        private readonly ICarService carService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CarController(IDashboardService dashboardService, ICarService carService, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
           this.dashboardService = dashboardService;
           this.carService = carService;
           this.userManager = userManager;
           this.webHostEnvironment = environment;
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

        [HttpGet]
        [Authorize]
        public IActionResult AddNewCar()
        {
            var viewModel = this.carService.GetNewCarViewModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddNewCar(AddNewCarViewModel model)
        {
           this.carService.SaveNewCar(model, this.User.FindFirstValue(ClaimTypes.NameIdentifier), $"{this.webHostEnvironment.WebRootPath}/images");

           return this.Redirect("MyCars");
        }

        [HttpGet]
        [Authorize]
        public IActionResult EditCar(int id)
        {
            var viewModel = this.carService.GetExistingCarForUpdate(id);
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult EditCar(AddNewCarViewModel updatedCar)
        {
            this.carService.UpdateCar(updatedCar);
            return this.RedirectToAction("MyCars");
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetModels(int carBrandId)
        {
            var jsonRes = this.carService.GetModels(carBrandId);
            return this.Json(jsonRes);
        }


        [Authorize]
        public IActionResult DeleteCar(int id)
        {
            this.carService.DeleteCar(id);
            return this.RedirectToAction("MyCars");
        }

        [HttpGet]
        [Authorize]
        public IActionResult MyCars(int id = 1)
        {
            const int ItemsPerPage = 12;
            var vm = new CarsViewModel()
            {
                PageNumber = id,
                ItemsPerPage = ItemsPerPage,
                CarsCount = this.dashboardService.GetCount(),
                Cars = this.dashboardService.GetMyCars(id, this.User.FindFirstValue(ClaimTypes.NameIdentifier), ItemsPerPage),
            };
            return this.View(vm);
        }
    }
}
