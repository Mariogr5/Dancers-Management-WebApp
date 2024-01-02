using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ptt_api.Entities;
using ptt_api.Exceptions;
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

        public void AddDancePairToDanceCompetitionCategory(int dancecompetitioncategoryid, int dancepairid)
        {
            var dancecompetitioncategor = _dancersDbContext
                .DanceCompetitionCategories
                .FirstOrDefault(r => r.Id == dancecompetitioncategoryid);
            var dancepair = _dancersDbContext
                .DancePairs
                .FirstOrDefault(r => r.Id == dancepairid);
            if (dancepair is null)
                throw new NotFoundException("Dance Pair not found");
            if (dancecompetitioncategor is null)
                throw new NotFoundException("Category not found");
            dancepair.DanceCompetitionCategoryId = dancecompetitioncategor.Id;
            _dancersDbContext.Update(dancepair);
            _dancersDbContext.SaveChanges();
        }
    }
}
