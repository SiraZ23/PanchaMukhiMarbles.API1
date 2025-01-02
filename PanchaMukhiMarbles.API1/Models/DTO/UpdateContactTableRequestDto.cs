using System.ComponentModel.DataAnnotations;

namespace PanchaMukhiMarbles.API1.Models.DTO
{
    public class UpdateContactTableRequestDto
    {

        [Required]
        public string[] PhoneNumber { get; set; }

        [Required]
        public string[] Whatsapp { get; set; }

        [Required]
        public string Gmail { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
