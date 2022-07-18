using System.ComponentModel.DataAnnotations;

namespace PortfolioMVC.Models
{
    public class Education
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter School Name")]
        [Display(Name = "School Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Short Description Of School")]
        [Display(Name = "Short Description")]
        [StringLength(50)]
        public string ShortDesc { get; set; }

        [Required(ErrorMessage = "Enter Long Description Of School")]
        [Display(Name = "Long Description")]
        [StringLength(50)]
        public string LongDesc { get; set; }

        [Required(ErrorMessage = "Enter Location of School")]
        [Display(Name = "Location")]
        [StringLength(50)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Enter Start Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Enter End Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
    }
}
