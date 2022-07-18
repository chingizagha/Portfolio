using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace PortfolioMVC.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Project Name")]
        [Display(Name = "Project Name")]
        [StringLength(100, MinimumLength = 4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Description")]
        [Display(Name = "Description")]
        [StringLength(500)]
        public string Desc { get; set; }

        [Required(ErrorMessage = "Enter Used Tech")]
        [Display(Name = "Used Tech")]
        [StringLength(500)]
        public string UsedTech { get; set; }

        [Required(ErrorMessage = "Enter Link")]
        [Display(Name = "Project Link")]
        [StringLength(100)]
        public string Link { get; set; }


        public int ImageId { get; set; }

        [BindNever]
        public Image Image { get; set; }
    }
}
