using ptt_api.Entities;

namespace ptt_api.Models
{
    public class DanceEventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public List<DanceCompetitionCategoryDto>? DanceCompetitionCategories { get; set; }
        public string City { get; set; }
        public string EmailAdress { get; set; }
        public DateTime Date { get; set; }
    }
}
