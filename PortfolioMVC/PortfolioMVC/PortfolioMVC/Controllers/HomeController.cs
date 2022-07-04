using Microsoft.AspNetCore.Mvc;
using PortfolioMVC.Models;
using PortfolioMVC.ViewModels;
using System.Diagnostics;

namespace PortfolioMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<Person> _personRepository;
        private readonly IGenericRepository<Career> _careerRepository;
        private readonly IGenericRepository<Education> _educationRepository;
        private readonly IGenericRepository<Skill> _skillRepository;
        private readonly IGenericRepository<Language> _languageRepository;
        private readonly IGenericRepository<Tool> _toolRepository;

        public HomeController(ILogger<HomeController> logger, 
            IGenericRepository<Person> personRepository, IGenericRepository<Career> careerRepository, IGenericRepository<Education> educationRepository,
            IGenericRepository<Skill> skillRepository, IGenericRepository<Language> languageRepository, IGenericRepository<Tool> toolRepository)
        {
            _logger = logger;
            _personRepository = personRepository;
            _careerRepository = careerRepository;
            _educationRepository = educationRepository;
            _skillRepository = skillRepository;
            _languageRepository = languageRepository;
            _toolRepository = toolRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                Person = _personRepository.GetAll,
                Careers = _careerRepository.GetAll,
                Educations = _educationRepository.GetAll,
                Skills = _skillRepository.GetAll,
                Languages = _languageRepository.GetAll,
                Tools = _toolRepository.GetAll
            };
            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}