using System.ComponentModel.DataAnnotations;

namespace PanchaMukhiMarbles.API1.Models.DTO
{
    public class UpdateHeroSectionRequestDto
    {
        [Required]
        public string HeroSectionTitle { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
