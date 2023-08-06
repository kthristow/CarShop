namespace CarShop.Services.Data
{
    using System.Collections.Generic;

    using CarShop.Web.ViewModels.Home;
    public interface IDashboardService
    {
        List<HomeVM> GetLastUploadedCars();
    }
}
