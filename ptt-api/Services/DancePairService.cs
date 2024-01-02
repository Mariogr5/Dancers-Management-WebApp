using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ptt_api.Entities;
using ptt_api.Models;

namespace ptt_api.Services
{
    public class DancePairService : IDancePairService
    {
        private readonly DancersDbContext _dancersDbContext;
        private readonly IMapper _danceClubMappingProfile;

        public DancePairService(DancersDbContext dancersDbContext, IMapper danceClubMappingProfile)
        {
            _dancersDbContext = dancersDbContext;
            _danceClubMappingProfile = danceClubMappingProfile;
        }

        public IEnumerable<DancePairDto> GetAll()
        {
            var allDancers = _dancersDbContext
                .DancePairs
                .ToList();
            var allDancersDto = _danceClubMappingProfile.Map<IEnumerable<DancePairDto>>(allDancers);
            return allDancersDto;
        }
    }
}
