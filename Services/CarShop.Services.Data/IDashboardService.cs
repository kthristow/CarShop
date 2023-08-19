namespace CarShop.Services.Data
{
    using System.Collections.Generic;

    using CarShop.Web.ViewModels.Home;

    public interface IDashboardService
    {
        List<CarViewModel> GetLastUploadedCars(int page, int itemsPerPage = 12);

        List<CarViewModel> GetMyCars(int page, string userId, int itemsPerPage = 12);

        int GetCount();

        HomePageViewModel GetHomePage(int count);
    }
}
