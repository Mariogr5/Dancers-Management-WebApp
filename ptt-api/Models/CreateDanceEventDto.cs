using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

namespace ptt_api.Models
{
    public class CreateDanceEventDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public bool IsCompetition { get; set; }
        [Required]
        public string Organizer { get; set; }   
        [Required]
        public string City { get; set; }
        [EmailAddress]
        public string EmailAdress { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
