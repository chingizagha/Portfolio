using System.ComponentModel.DataAnnotations;

namespace PortfolioMVC.Models
{
    public class Language
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name of Language")]
        [Display(Name = "Language Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Level")]
        [Display(Name = "Level")]
        [Range(0, 5)]
        public int Level { get; set; }
    }
}
