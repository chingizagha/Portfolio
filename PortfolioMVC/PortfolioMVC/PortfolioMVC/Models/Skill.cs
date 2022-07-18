using System.ComponentModel.DataAnnotations;

namespace PortfolioMVC.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name of Skill")]
        [Display(Name = "Skill Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Level")]
        [Display(Name = "Level")]
        [Range(0, 5)]
        public int Level { get; set; }
    }
}
