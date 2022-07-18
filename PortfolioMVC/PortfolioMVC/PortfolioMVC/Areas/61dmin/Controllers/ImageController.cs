using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioMVC.Models;
using PortfolioMVC.ViewModels;
using System.Data;

namespace PortfolioMVC.Areas.Admin.Controllers
{
    [Area("61dmin")]
    [Authorize]
    public class ImageController : Controller
    {
        private readonly IGenericRepository<Image> _genericRepository;
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageController(IGenericRepository<Image> genericRepository, AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _genericRepository = genericRepository;
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult List()
        {
            var homeViewModel = new HomeViewModel()
            {
                Images = _genericRepository.GetAll
            };

            return View(homeViewModel);
        }

        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(include: "Id, Title, ImageFile")] Image image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
                    string extension = Path.GetExtension(image.ImageFile.FileName);
                    image.Name = fileName = fileName + DateTime.Now.ToString("ddmmyyyy") + extension;
                    string path = Path.Combine(wwwRootPath + "/image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await image.ImageFile.CopyToAsync(fileStream);
                    }


                    _genericRepository.Add(image);
                    await _appDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(List));
                }
            }
            catch (DataException dex)
            {

                ModelState.AddModelError($"{dex}", "Unable to save changes. Try again, and if the problem persists see your system administrator."); ;
            }
            return View(image);
        }

        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //    var person = _genericRepository.GetById(id);
        //    if (person == null)
        //        return RedirectToAction(nameof(List));
        //    return View(person);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Update([Bind("Id, ImageFile")] Person person)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _genericRepository.Update(person);
        //            await _appDbContext.SaveChangesAsync();
        //            return RedirectToAction(nameof(List));
        //        }
        //        catch (DbUpdateException ex)
        //        {
        //            ModelState.AddModelError($"{ex}", "Unable to save changes. " +
        //                "Try again, and if the problem persists, " +
        //                "see your system administrator.");
        //        }
        //    }
        //    return View(person);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            var imageModel = await _appDbContext.Images.FindAsync(id);

            //delete image from wwwroot/image
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "image", imageModel.Name);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            _genericRepository.Remove(id);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
