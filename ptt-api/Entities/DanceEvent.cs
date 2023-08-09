using System.Diagnostics.Contracts;

namespace ptt_api.Entities
{
    public class DanceEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public bool IsCompetition { get; set; }
        public List<DanceCompetitionCategory>? DanceCompetitionCategories { get; set; } = new List<DanceCompetitionCategory>();
        public string City { get; set; }
        public string EmailAdress { get; set; }
        public DateTime Date { get; set; }

    }
}
