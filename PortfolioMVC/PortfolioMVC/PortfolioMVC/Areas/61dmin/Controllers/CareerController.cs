using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioMVC.Models;
using PortfolioMVC.ViewModels;
using System.Data;

namespace PortfolioMVC.Areas.Admin.Controllers
{
    [Area("61dmin")]
    [Authorize]
    public class CareerController : Controller
    {
        private readonly IGenericRepository<Career> _genericRepository;
        private readonly AppDbContext _appDbContext;

        public CareerController(IGenericRepository<Career> genericRepository, AppDbContext appDbContext)
        {
            _genericRepository = genericRepository;
            _appDbContext = appDbContext;
        }

        public IActionResult List()
        {
            var homeViewModel = new HomeViewModel()
            {
                Careers = _genericRepository.GetAll
            };

            return View(homeViewModel);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var item = _genericRepository.GetById(id);
            if (item == null)
                return RedirectToAction(nameof(List));
            return View(item);
        }

        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(include: "Name, ShortDesc, LongDesc, Location, Link, StartDate, EndDate")] Career career)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _genericRepository.Add(career);
                    await _appDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(List));
                }
            }
            catch (DataException dex)
            {

                ModelState.AddModelError($"{dex}", "Unable to save changes. Try again, and if the problem persists see your system administrator."); ;
            }
            return View(career);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var person = _genericRepository.GetById(id);
            if (person == null)
                return RedirectToAction(nameof(List));
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([Bind("Id, Name, ShortDesc, LongDesc, Location, Link, StartDate, EndDate")] Career career)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _genericRepository.Update(career);
                    await _appDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(List));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError($"{ex}", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(career);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            _genericRepository.Remove(id);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
