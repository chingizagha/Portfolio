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
    public class ProjectController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IProjectRepository _projectRepository;

        public ProjectController(AppDbContext appDbContext, IProjectRepository projectRepository)
        {
            _appDbContext = appDbContext;
            _projectRepository = projectRepository;
        }

        public IActionResult List()
        {
            var homeViewModel = new HomeViewModel()
            {
                Projects = _projectRepository.GetAll
            };

            return View(homeViewModel);
        }

        public IActionResult Detail(int id)
        {
            var project = _projectRepository.GetById(id);
            if(project == null)
            {
                return View("Error");
            }
            return View(project);
        }

        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(include: "Name, Desc, UsedTech, Link, ImageId")] Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _projectRepository.Add(project);
                    await _appDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(List));
                }
            }
            catch (DataException dex)
            {

                ModelState.AddModelError($"{dex}", "Unable to save changes. Try again, and if the problem persists see your system administrator."); ;
            }
            return View(project);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var project = _projectRepository.GetById(id);
            if (project == null)
                return RedirectToAction(nameof(List));
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([Bind("Id, Name, Desc, UsedTech, Link, ImageId")] Project project)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _projectRepository.Update(project);
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
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            _projectRepository.Remove(id);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

    }
}
