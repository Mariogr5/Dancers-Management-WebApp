using System.ComponentModel.DataAnnotations;

namespace ptt_api.Models
{
    public class UpdateDanceClubDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        public string Owner { get; set; }
    }
}
