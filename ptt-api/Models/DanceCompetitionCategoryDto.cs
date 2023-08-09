using ptt_api.Entities;

namespace ptt_api.Models
{
    public class DanceCompetitionCategoryDto
    {
        public int Id { get; set; }
        public string AgeRange { get; set; }
        public string CategoryDanceClass { get; set; }
        public List<DancePairDto> ListofPairs { get; set; }
    }
}
