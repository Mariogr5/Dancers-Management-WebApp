using Microsoft.EntityFrameworkCore;
using ptt_api.Entities;

namespace ptt_api.Services
{
    public class DanceClubService : IDanceClubService
    {
        private readonly DancersDbContext _dancersDbContext;

        public DanceClubService(DancersDbContext dancersDbContext)
        {
            _dancersDbContext = dancersDbContext;
        }
        public IEnumerable<DanceClub> GetAll()
        {
            var danceclubs = _dancersDbContext
                .DanceClubs
                .ToList();
            return danceclubs;
        }
        public DanceClub GetById(int id)
        {
            var searchedDanceCloub = _dancersDbContext
                .DanceClubs
                .FirstOrDefault(r => r.Id == id);
            return searchedDanceCloub;
        }
    }
}
