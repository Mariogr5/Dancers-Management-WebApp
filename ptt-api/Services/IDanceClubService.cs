using ptt_api.Entities;

namespace ptt_api.Services
{
    public interface IDanceClubService
    {
        IEnumerable<DanceClub> GetAll();
        DanceClub GetById(int id);
    }
}