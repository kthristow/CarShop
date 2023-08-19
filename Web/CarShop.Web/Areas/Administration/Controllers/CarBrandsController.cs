namespace CarShop.Web.Areas.Administration.Controllers
{
    using CarShop.Data;
    using CarShop.Data.Common.Models;
    using CarShop.Data.Common.Repositories;
    using CarShop.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Administration")]
    public class CarBrandsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<CarBrand> repository;

        public CarBrandsController(IDeletableEntityRepository<CarBrand> repository)
        {
            this.repository = repository;
        }

        // GET: Administration/CarBrands
        public async Task<IActionResult> Index()
        {
            return View(await this.repository.All().ToListAsync());
        }

        // GET: Administration/CarBrands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carBrand = await this.repository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carBrand == null)
            {
                return NotFound();
            }

            return View(carBrand);
        }

        // GET: Administration/CarBrands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administration/CarBrands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandName,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] CarBrand carBrand)
        {
            if (ModelState.IsValid)
            {
                await this.repository.AddAsync(carBrand);
                await this.repository.SaveChangesAsync();
                return this.RedirectToAction(nameof(Index));
            }
            return this.View(carBrand);
        }

        // GET: Administration/CarBrands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || this.repository.All() == null)
            {
                return NotFound();
            }

            var carBrand = await this.repository.All().FirstOrDefaultAsync(x => x.Id == id);
            if (carBrand == null)
            {
                return NotFound();
            }
            return View(carBrand);
        }

        // POST: Administration/CarBrands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrandName,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] CarBrand carBrand)
        {
            if (id != carBrand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.Update(carBrand);
                    await this.repository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarBrandExists(carBrand.Id))
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
            return View(carBrand);
        }

        // GET: Administration/CarBrands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || this.repository.All() == null)
            {
                return NotFound();
            }

            var carBrand = await this.repository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carBrand == null)
            {
                return NotFound();
            }

            return View(carBrand);
        }

        // POST: Administration/CarBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (this.repository.All() == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CarBrands'  is null.");
            }
            var carBrand = await this.repository.All().FirstOrDefaultAsync(x => x.Id == id);
            if (carBrand != null)
            {
                this.repository.Delete(carBrand);
            }

            await this.repository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarBrandExists(int id)
        {
            return this.repository.All().Any(e => e.Id == id);
        }
    }
}
