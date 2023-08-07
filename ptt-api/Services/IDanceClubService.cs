using ptt_api.Entities;
using ptt_api.Models;

namespace ptt_api.Services
{
    public interface IDanceClubService
    {
        IEnumerable<DanceClubDto> GetAll();
        DanceClubDto GetById(int id);
        int Create(CreateDanceClubDto dto);
        void Delete(int id);
        void Update(int id, UpdateDanceClubDto dto);
    }
}