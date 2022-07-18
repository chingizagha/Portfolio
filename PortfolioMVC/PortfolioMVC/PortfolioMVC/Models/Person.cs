using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace PortfolioMVC.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Person Name")]
        [Display(Name = "Person Name")]
        [StringLength(50 ,MinimumLength = 4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Person Age")]
        [Display(Name = "Age")]
        [Range(0, 100)]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter Location")]
        [Display(Name = "Location")]
        [StringLength(50)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Enter Job Description")]
        [Display(Name = "Job Description")]
        [StringLength(50)]
        public string JobDesc { get; set; }

        [Required(ErrorMessage = "Enter Information About Yourself")]
        [Display(Name = "Person Description")]
        [StringLength(500)]
        public string AboutMe { get; set; }

        public int ImageId { get; set; }

        [BindNever]
        public Image Image { get; set; }
    }
}
