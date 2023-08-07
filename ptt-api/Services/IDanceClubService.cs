using ptt_api.Entities;
using ptt_api.Models;

namespace ptt_api.Services
{
    public interface IDanceClubService
    {
        IEnumerable<DanceClubDto> GetAll();
        DanceClubDto GetById(int id);
        int Create(CreateDanceClubDto dto);
        bool Delete(int id);
        bool Update(int id, UpdateDanceClubDto dto);
    }
}