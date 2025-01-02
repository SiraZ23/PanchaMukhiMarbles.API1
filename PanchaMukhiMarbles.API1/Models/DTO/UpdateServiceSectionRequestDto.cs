using System.ComponentModel.DataAnnotations;

namespace PanchaMukhiMarbles.API1.Models.DTO
{
    public class UpdateServiceSectionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Page Title has to be a minimum Of 3 characters")]
        [MaxLength(15, ErrorMessage = "Page Title has to be a maximum Of 15 characters")]
        public string PageTitle { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Service Title has to be a minimum Of 3 characters")]
        [MaxLength(15, ErrorMessage = "Service Title has to be a maximum Of 15 characters")]
        public string ServiceTitle { get; set; }
        public string? ServiceDescription { get; set; }
    }
}
