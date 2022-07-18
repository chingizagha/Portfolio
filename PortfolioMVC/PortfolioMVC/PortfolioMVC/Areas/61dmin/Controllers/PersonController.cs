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
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly AppDbContext _appDbContext;

        public PersonController(IPersonRepository personRepository, AppDbContext appDbContext)
        {
            _personRepository = personRepository;
            _appDbContext = appDbContext;
        }

        public IActionResult List()
        {
            var homeViewModel = new HomeViewModel()
            {
                Person = _personRepository.GetAll
            };

            return View(homeViewModel);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var item = _personRepository.GetById(id);
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
        public async Task<ActionResult> Add([Bind(include: "Name, Age, Location, AboutMe, JobDesc, ImageId")] Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _personRepository.Add(person);
                    await _appDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(List));
                }
            }
            catch (DataException dex )
            {

                ModelState.AddModelError($"{dex}","Unable to save changes. Try again, and if the problem persists see your system administrator."); ;
            }
            return View(person);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var person = _personRepository.GetById(id);
            if (person == null)
                return RedirectToAction(nameof(List));
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([Bind("Id, Name, Age, Location, AboutMe, JobDesc, ImageId")] Person person)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _personRepository.Update(person);
                    await _appDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(List));
                }
                catch (DbUpdateException ex )
                {
                    ModelState.AddModelError($"{ex}", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(person);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            _personRepository.Remove(id);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
