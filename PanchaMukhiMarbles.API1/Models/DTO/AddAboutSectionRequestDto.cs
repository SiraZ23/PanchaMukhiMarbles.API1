using System.ComponentModel.DataAnnotations;

namespace PanchaMukhiMarbles.API1.Models.DTO
{
    public class AddAboutSectionRequestDto
    {
        [Required]
        [MinLength(3,ErrorMessage ="Title has to be a minimum Of 3 characters")]
        [MaxLength(15, ErrorMessage = "Title has to be a maximum Of 15 characters")]
        public string Title { get; set; } 

        [Required]
        [MaxLength(50, ErrorMessage = "Paragraph has to be a maximum Of 50 characters")]
        public string Paragraph { get; set; }

        [Required]  
        public string ImageUrl { get; set; }
    }
}
