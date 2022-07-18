using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioMVC.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Required(ErrorMessage = "Enter Title for Image")]
        [Display(Name = "Title")]
        [StringLength(50)]
        public string Title { get; set; }

        [Display(Name = "Image Name")]
        public string Name { get; set; }

        [NotMapped]
        [DisplayName("Image File")]
        public IFormFile ImageFile { get; set; }

        public List<Person> Person { get; set; }
        public List<Project> Project { get; set; }
    }
}
