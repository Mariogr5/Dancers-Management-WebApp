using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ptt_api.Entities;
using ptt_api.Exceptions;
using ptt_api.Models;

namespace ptt_api.Services
{
    public class DancerService : IDancerService
    {
        private readonly DancersDbContext _dancersDbContext;
        private readonly IMapper _danceClubMappingProfile;

        public DancerService(DancersDbContext dancersDbContext, IMapper danceClubMappingProfile)
        {
            _dancersDbContext = dancersDbContext;
            _danceClubMappingProfile = danceClubMappingProfile;
        }
        public IEnumerable<DancerDto> GetAll()
        {
            var allDancers = _dancersDbContext
                .Dancers
                .Include(r => r.DancerClub)
                .ToList();
            var allDancersDto = _danceClubMappingProfile.Map<IEnumerable<DancerDto>>(allDancers);
            return allDancersDto;
        }

        public DancerDto GetById(int id)
        {
            var searchedDancer = _dancersDbContext
                .Dancers
                .Include(r => r.DancerClub)
                .FirstOrDefault(r => r.Id == id);
                
            if (searchedDancer is null)
                throw new NotFoundException("Dancer not found");
            var searchedDancerDto = _danceClubMappingProfile.Map<DancerDto>(searchedDancer);
            return searchedDancerDto;
        }
        public IEnumerable<DancerDto> GetDancersByClubId(int DanceClubId)
        {
            var searchedDancers = _dancersDbContext
                .Dancers
                .Where(r => r.DancerClub.Id == DanceClubId)
                .ToList();
            if (!searchedDancers.Any())
                throw new NotFoundException("DanceClub not found");
            var searchedDancersDto = _danceClubMappingProfile.Map<IEnumerable<DancerDto>>(searchedDancers);
            return searchedDancersDto;
        }
        public int CreateDancer(int DanceClubId, CreateDancerDto dto)
        {
            var newDancer = _danceClubMappingProfile.Map<Dancer>(dto);
            newDancer.DancePartnerName = "none";
            newDancer.NumberofPoints = 0;
            newDancer.DanceClubId = DanceClubId;
            _dancersDbContext.Dancers.Add(newDancer);
            _dancersDbContext.SaveChanges();
            return newDancer.Id;
        }

        public void Delete(int id)
        {
            var deletedDancer = _dancersDbContext
                .Dancers
                .FirstOrDefault(r =>r.Id == id);
            if(deletedDancer is null)
                throw new NotFoundException("Dancer not found");
            _dancersDbContext.Dancers.Remove(deletedDancer);
            _dancersDbContext.SaveChanges();
        }

        public void PairtheDancers(int id, int PartnerId)
        {
            var dancer = _dancersDbContext
                .Dancers
                .FirstOrDefault(r => r.Id == id);
            if (dancer is null)
                throw new NotFoundException("Dancer not found");
            var dancePartner = _dancersDbContext
                .Dancers
                .FirstOrDefault(r => r.Id == PartnerId);
            if (dancePartner is null)
                throw new NotFoundException("Dancepartner not found");
            dancer.DancePartnerName = dancePartner.Name;
            dancePartner.DancePartnerName = dancer.Name;
            _dancersDbContext.Update(dancer);
            _dancersDbContext.Update(dancePartner);
            _dancersDbContext.SaveChanges();
        }

    }
}
