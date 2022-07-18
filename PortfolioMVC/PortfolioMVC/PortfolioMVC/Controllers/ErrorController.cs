using Microsoft.AspNetCore.Mvc;

namespace PortfolioMVC.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult PageNotFound(int statusCode)
        {
            switch (statusCode)
            {
                case 404: ViewBag.errorMessage = "Page not found";
                    break;
            }
            return View("PageNotFound");
        }
    }
}
