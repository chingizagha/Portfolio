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
    public class LanguageController : Controller
    {
        private readonly IGenericRepository<Language> _genericRepository;
        private readonly AppDbContext _appDbContext;

        public LanguageController(IGenericRepository<Language> genericRepository, AppDbContext appDbContext)
        {
            _genericRepository = genericRepository;
            _appDbContext = appDbContext;
        }

        public IActionResult List()
        {
            var homeViewModel = new HomeViewModel()
            {
                Languages = _genericRepository.GetAll
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
        public async Task<ActionResult> Add([Bind(include: "Name, Level")] Language language)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _genericRepository.Add(language);
                    await _appDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(List));
                }
            }
            catch (DataException dex)
            {

                ModelState.AddModelError($"{dex}", "Unable to save changes. Try again, and if the problem persists see your system administrator."); ;
            }
            return View(language);
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
        public async Task<IActionResult> Update([Bind("Id, Name, Level")] Language language)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _genericRepository.Update(language);
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
            return View(language);
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
