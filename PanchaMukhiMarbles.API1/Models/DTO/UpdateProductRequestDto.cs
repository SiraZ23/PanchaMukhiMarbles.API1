using System.ComponentModel.DataAnnotations;

namespace PanchaMukhiMarbles.API1.Models.DTO
{
    public class UpdateProductRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Product Name has to be a minimum Of 3 characters")]
        [MaxLength(15, ErrorMessage = "Product Name has to be a maximum Of 15 characters")]
        public string ProductName { get; set; }
        public string? Thickness { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public float Price { get; set; }
        public string? Stock { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
