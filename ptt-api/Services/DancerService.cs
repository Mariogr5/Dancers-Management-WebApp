using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ptt_api.Entities;
using ptt_api.Exceptions;
using ptt_api.Models;
using System.Data;

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
                .Include(r => r.DancerClub)
                .Where(r => r.DancerClub.Id == DanceClubId)
                .ToList();
            if (!searchedDancers.Any())
                throw new NotFoundException("DanceClub not found");
            var searchedDancersDto = _danceClubMappingProfile.Map<IEnumerable<DancerDto>>(searchedDancers);
            return searchedDancersDto;
        }

        public IEnumerable<DancerDto> GetDancersByDanceClass(string danceclass)
        {
            var searchedDancers = _dancersDbContext
                .Dancers
                .Include(r => r.DancerClub)
                .Where(r => r.Danceclass == danceclass)
                .ToList();
            if (!searchedDancers.Any())
                throw new NotFoundException("Searched DanceClass Dancers not found");
            var searchedDancersDto = _danceClubMappingProfile.Map<IEnumerable<DancerDto>>(searchedDancers);
            return searchedDancersDto;
        }
        public int CreateDancer(int DanceClubId, CreateDancerDto dto)
        {
            var newDancer = _danceClubMappingProfile.Map<Dancer>(dto);
            newDancer.DancePartnerId = null;
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
            var deletedDancerPair = _dancersDbContext
                .DancePairs
                .Where(r => r.DancerId == deletedDancer.Id || r.DancerId == deletedDancer.DancePartnerId)
                .FirstOrDefault();
            _dancersDbContext.Dancers.Remove(deletedDancer);
            _dancersDbContext.SaveChanges();
        }
        public void ChangeDancerClub(int id, int danceClubId)
        {
            var dancer = _dancersDbContext
                .Dancers
                .FirstOrDefault(r => r.Id==id);
            var danceclub = _dancersDbContext
                .DanceClubs
                .FirstOrDefault(r => r.Id == danceClubId);
            if (dancer is null)
                throw new NotFoundException("Dancer not found");
            if (danceclub is null)
                throw new NotFoundException("Dance Club not found");
            if (dancer.DancePartnerName != "none")
            {
                var dancePartner = _dancersDbContext
                    .Dancers
                    .FirstOrDefault(r => r.Name == dancer.DancePartnerName);
                dancer.DancePartnerName = "none";
                dancePartner.DancePartnerName = "none";
                _dancersDbContext.Update(dancePartner);
            }
            dancer.DanceClubId = danceClubId;
            dancer.DancerClub = danceclub;
            _dancersDbContext.Update(dancer);
            _dancersDbContext.SaveChanges();
        }
    }
}
