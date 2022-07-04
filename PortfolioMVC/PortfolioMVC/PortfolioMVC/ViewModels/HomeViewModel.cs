using PortfolioMVC.Models;

namespace PortfolioMVC.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Person> Person { get; set; }
        public IEnumerable<Career> Careers { get; set; }
        public IEnumerable<Education> Educations { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<Tool> Tools { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}
