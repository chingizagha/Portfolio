using System.ComponentModel.DataAnnotations;

namespace PortfolioMVC.Models
{
    public class Career
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Company Name")]
        [Display(Name = "Company Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Short Description Of Company")]
        [Display(Name = "Short Description")]
        [StringLength(50)]
        public string ShortDesc { get; set; }

        [Required(ErrorMessage = "Enter Long Description Of Company")]
        [Display(Name = "Long Description")]
        [StringLength(50)]
        public string LongDesc { get; set; }

        [Required(ErrorMessage = "Enter Location of Company")]
        [Display(Name = "Location")]
        [StringLength(50)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Enter Link of Company")]
        [Display(Name = "Link")]
        [StringLength(50)]
        public string Link { get; set; }

        [Required(ErrorMessage = "Enter Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/mm/yyyy}")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Enter End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/mm/yyyy}")]
        public DateTime EndDate { get; set; }
    }
}
