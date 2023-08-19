namespace CarShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CarShop.Web.ViewModels.Car;

    public interface ICarService
    {
        AddNewCarViewModel GetNewCarViewModel();

        Dictionary<string, string> GetModels(int id);

        void SaveNewCar(AddNewCarViewModel viewModel, string userId, string imagePath);

        DetailsCarViewModel GetCarById(int id);

        AddNewCarViewModel GetExistingCarForUpdate(int id);

        void UpdateCar(AddNewCarViewModel viewModel);

        void DeleteCar(int id);
    }
}
