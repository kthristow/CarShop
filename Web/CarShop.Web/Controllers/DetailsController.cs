namespace CarShop.Web.Controllers
{
    using CarShop.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class DetailsController : BaseController
    {
        private readonly ICarService carService;

        public DetailsController(ICarService carService)
        {
            this.carService = carService;
        }

        public IActionResult GetCarById(int id)
        {
            var model = this.carService.GetCarById(id);
            return this.View(model);
        }
    }
}
