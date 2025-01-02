using System.ComponentModel.DataAnnotations;

namespace PanchaMukhiMarbles.API1.Models.DTO
{
    public class UpdateLogoRequestDto
    {
        [Required]
        public string LogoName { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
