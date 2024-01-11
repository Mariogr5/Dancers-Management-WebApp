using ptt_api.Models;

namespace ptt_api.Services
{
    public interface IDancePairService
    {
        IEnumerable<DancePairDto> GetAll();
        DancePairDto GetPairById(int id);
        void AddDancePairToDanceCompetitionCategory(int dancecompetitioncategoryid, int dancepairid);
        int PairtheDancers(int id, int partnerid, CreateDancePairDto dto);

        void DeletePair(int id);
    }
}