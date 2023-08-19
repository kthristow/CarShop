namespace CarShop.Web.Areas.Administration.Controllers
{
    using CarShop.Data.Common.Repositories;
    using CarShop.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Administration")]
    public class CarModelsController : Controller
    {
        private readonly IDeletableEntityRepository<CarBrand> carBrandRepo;
        private readonly IDeletableEntityRepository<CarModel> carModelRepo;

        public CarModelsController(IDeletableEntityRepository<CarBrand> carBrandRepo, IDeletableEntityRepository<CarModel> carModelRepo)
        {
            this.carBrandRepo = carBrandRepo;
            this.carModelRepo = carModelRepo;
        }

        // GET: Administration/CarModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.carModelRepo.All().Include(c => c.CarBrand);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/CarModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || this.carModelRepo.All() == null)
            {
                return NotFound();
            }

            var carModel = await this.carModelRepo.All()
                .Include(c => c.CarBrand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carModel == null)
            {
                return NotFound();
            }

            return View(carModel);
        }

        // GET: Administration/CarModels/Create
        public IActionResult Create()
        {
            ViewData["CarBrandId"] = new SelectList(this.carBrandRepo.All(), "Id", "Id");
            return View();
        }

        // POST: Administration/CarModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModelName,CarBrandId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                await this.carModelRepo.AddAsync(carModel);
                await this.carModelRepo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarBrandId"] = new SelectList(this.carBrandRepo.All(), "Id", "Id", carModel.CarBrandId);
            return View(carModel);
        }

        // GET: Administration/CarModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || this.carModelRepo.All() == null)
            {
                return NotFound();
            }

            var carModel = await this.carModelRepo.All().FirstOrDefaultAsync(x => x.Id == id);
            if (carModel == null)
            {
                return NotFound();
            }
            ViewData["CarBrandId"] = new SelectList(this.carModelRepo.All(), "Id", "Id", carModel.CarBrandId);
            return View(carModel);
        }

        // POST: Administration/CarModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModelName,CarBrandId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] CarModel carModel)
        {
            if (id != carModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.carModelRepo.Update(carModel);
                    await this.carModelRepo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarModelExists(carModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarBrandId"] = new SelectList(this.carBrandRepo.All(), "Id", "Id", carModel.CarBrandId);
            return View(carModel);
        }

        // GET: Administration/CarModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || this.carModelRepo.All() == null)
            {
                return NotFound();
            }

            var carModel = await this.carModelRepo.All()
                .Include(c => c.CarBrand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carModel == null)
            {
                return NotFound();
            }

            return View(carModel);
        }

        // POST: Administration/CarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (this.carModelRepo.All() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CarModels'  is null.");
            }
            var carModel = await this.carModelRepo.All().FirstOrDefaultAsync(x => x.Id == id);
            if (carModel != null)
            {
                this.carModelRepo.Delete(carModel);
            }
            
            await this.carModelRepo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarModelExists(int id)
        {
          return this.carModelRepo.All().Any(e => e.Id == id);
        }
    }
}
