using ptt_api.Models;

namespace ptt_api.Services
{
    public interface IDancePairService
    {
        IEnumerable<DancePairDto> GetAll();
        void AddDancePairToDanceCompetitionCategory(int dancecompetitioncategoryid, int dancepairid);
    }
}