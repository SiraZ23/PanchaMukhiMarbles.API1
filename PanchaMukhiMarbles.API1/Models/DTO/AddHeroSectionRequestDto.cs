using System.ComponentModel.DataAnnotations;

namespace PanchaMukhiMarbles.API1.Models.DTO
{
    public class AddHeroSectionRequestDto
    {
        [Required]
        public string HeroSectionTitle { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
