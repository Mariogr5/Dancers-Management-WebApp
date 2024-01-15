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
        public DancePairDto GetPairByDancerId(int dancerid)
        {
            var searchedpair = _dancersDbContext.DancePairs.FirstOrDefault(r => r.DancerId == dancerid || r.DancePartnerId == dancerid);
            if (searchedpair is null)
                throw new NotFoundException("Pair not found");
            var result = _danceClubMappingProfile.Map<DancePairDto>(searchedpair);
            return result;
        }
        public DancePairDto GetPairById(int id)
        {
            var searchedpair = _dancersDbContext.DancePairs.FirstOrDefault(r => r.Id == id);
            if (searchedpair is null)
                throw new NotFoundException("Pair not found");
            var result = _danceClubMappingProfile.Map<DancePairDto>(searchedpair);
            return result;
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
            if (dancepair.PairDanceClass != dancecompetitioncategor.CategoryDanceClass)
                throw new BadRequestException("Dance Pair and Category have diffrent Dance Class!");
            dancepair.DanceCompetitionCategoryId = dancecompetitioncategor.Id;
            _dancersDbContext.Update(dancepair);
            _dancersDbContext.SaveChanges();
        }

        public int PairtheDancers(int id, int partnerid, CreateDancePairDto dto)
        {
            //new DancePair("Jaś Fasola", "Zosia Kłosia", "B", 0, "Oborniki Wrocław")
            using (var transaction = _dancersDbContext.Database.BeginTransaction())
            {
                try
                {
                    var dancer = _dancersDbContext.Dancers.FirstOrDefault(r => r.Id == id);
                    var dancepartner = _dancersDbContext.Dancers.FirstOrDefault(r => r.Id == partnerid);
                    if(dancepartner is null || dancer is null)
                        throw new NotFoundException("Dancers not found");
                    if (dancer.DanceClubId != dancepartner.DanceClubId)
                        throw new BadRequestException("Dancers are from diffrent Clubs. First change Dance Partner Club");
                    if(dancer.DancePartnerId == dancepartner.Id || dancer.DancePartnerId != null || dancepartner.DancePartnerId != null)
                        throw new BadRequestException("Dancers are already in the pair");
                    var dancerclub = _dancersDbContext.DanceClubs.FirstOrDefault(r => r.Id == dancer.DanceClubId);
                    dancer.DancePartnerName = dancepartner.Name;
                    dancer.DancePartnerId = dancepartner.Id;
                    dancepartner.DancePartnerName = dancer.Name;
                    dancepartner.DancePartnerId = dancer.Id;
                    _dancersDbContext.SaveChanges();
                    var newdancepair = _danceClubMappingProfile.Map<DancePair>(dto);
                    newdancepair.DancerId = id;
                    newdancepair.DancePartnerId = partnerid;
                    newdancepair.DancePairClubName = dancerclub.Name;
                    newdancepair.DanceClubId = dancerclub.Id;
                    newdancepair.DancerName = dancer.Name;
                    newdancepair.DancePartnerName = dancepartner.Name;
                    newdancepair.DanceCompetitionCategoryId = null;
                    newdancepair.DanceCompetitionCategory = null;

                    _dancersDbContext.Add(newdancepair);
                    _dancersDbContext.SaveChanges();

                    transaction.Commit();
                    return newdancepair.Id;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw new BadRequestException(ex.Message);
                }
            }
            
        }

        public void DeletePair(int id)
        {
            var deletedpair = _dancersDbContext.DancePairs.FirstOrDefault(r => r.Id == id);
            if (deletedpair is null)
                throw new NotFoundException("Dance Pair not found");
            var dancer = _dancersDbContext.Dancers.FirstOrDefault(r => r.Id == deletedpair.DancerId);
            var dancepartner = _dancersDbContext.Dancers.FirstOrDefault(r => r.Id == deletedpair.DancePartnerId);
            dancer.DancePartnerId = null;
            dancer.DancePartnerName = "none";
            dancepartner.DancePartnerId = null;
            dancepartner.DancePartnerName = "none";
            _dancersDbContext.Remove(deletedpair);
            _dancersDbContext.SaveChanges();
        }
    }
}
