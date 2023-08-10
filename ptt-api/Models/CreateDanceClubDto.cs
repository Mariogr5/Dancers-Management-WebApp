using System.ComponentModel.DataAnnotations;

namespace ptt_api.Models
{
    public class CreateDanceClubDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        public string Owner { get; set; }
        [Required]
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
