using Microsoft.AspNetCore.Mvc;
using PortfolioMVC.Models;
using System.Linq;

namespace PortfolioMVC.Areas.Admin.Components
{
    public class ImageSelect : ViewComponent
    {
        private readonly IGenericRepository<Image> _genericRepository;

        public ImageSelect(IGenericRepository<Image> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public IViewComponentResult Invoke()
        {
            var images = _genericRepository.GetAll.OrderBy(c => c.Title);
            return View(images);
        }
    }
}