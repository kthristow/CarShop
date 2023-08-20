using CarShop.Data.Common.Repositories;
using CarShop.Data.Models;
using CarShop.Data.Repositories;
using CarShop.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using CarShop.Web.ViewModels.Home;

namespace CarShop.Services.Data.Tests
{
    public class DashboardServiceTest
    {
        [Fact]
        public void GetCountShouldReturnCorrectNumber()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                 .UseInMemoryDatabase(databaseName: "SettingsTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);
            var cars = new List<Car>();
            cars.Add(new Car());
            cars.Add(new Car());
            cars.Add(new Car());
            dbContext.Cars.AddRange(cars);
            dbContext.SaveChanges();

            var service = new DashboardService(dbContext, null);
            Assert.Equal(3, service.GetCount());
        }

        //[Fact]
        //public void GetLastUpdatedCars()
        //{
        //    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        //         .UseInMemoryDatabase(databaseName: "SettingsTestDb").Options;
        //    using var dbContext = new ApplicationDbContext(options);
        //    var cars = new List<Car>();
        //    cars.Add(new Car());
        //    cars.Add(new Car());
        //    cars.Add(new Car());
        //    dbContext.Cars.AddRange(cars);
        //    dbContext.SaveChanges();


        //    var vm = new List<CarsViewModel>();
        //    vm.Add(new CarsViewModel());
        //    vm.Add(new CarsViewModel());
        //    vm.Add(new CarsViewModel());

        //    var service = new DashboardService(dbContext, null);
        //    var lastUploaded = service.GetLastUploadedCars(1, 3);
        //    Assert.Equal(vm.Count, lastUploaded.Count);
        //}
    }
}
