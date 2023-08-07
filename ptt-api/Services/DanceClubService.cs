using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ptt_api.Entities;
using ptt_api.Exceptions;
using ptt_api.Models;

namespace ptt_api.Services
{
    public class DanceClubService : IDanceClubService
    {
        private readonly DancersDbContext _dancersDbContext;
        private readonly IMapper _danceClubMappingProfile;

        public DanceClubService(DancersDbContext dancersDbContext, IMapper danceClubMappingProfile)
        {
            _dancersDbContext = dancersDbContext;
            _danceClubMappingProfile = danceClubMappingProfile;
        }
        public IEnumerable<DanceClubDto> GetAll()
        {
            var danceclubs = _dancersDbContext
                .DanceClubs
                .Include(r => r.Dancers)
                .Include(r => r.Address)
                .ToList();
            var danceclubsDto = _danceClubMappingProfile.Map<List<DanceClubDto>>(danceclubs);
            return danceclubsDto;
        }
        public DanceClubDto GetById(int id)
        {
            var searchedDanceClub = _dancersDbContext
                .DanceClubs
                .Include(r => r.Dancers)
                .Include(r => r.Address)
                .FirstOrDefault(r => r.Id == id);
            if(searchedDanceClub is null)
                throw new NotFoundException("DanceClub not found");
            var searchedDanceClubDto = _danceClubMappingProfile.Map<DanceClubDto>(searchedDanceClub);
            return searchedDanceClubDto;
        }

        public int Create(CreateDanceClubDto dto)
        {
            var newDanceClub = _danceClubMappingProfile.Map<DanceClub>(dto);
            _dancersDbContext.DanceClubs.Add(newDanceClub);
            _dancersDbContext.SaveChanges();
            return newDanceClub.Id;
        }

        public void Delete(int id)
        {
            var searchedDanceClub = _dancersDbContext
                .DanceClubs
                .FirstOrDefault(r => r.Id == id);
            if (searchedDanceClub is null)
                throw new NotFoundException("DanceClub not found");
            _dancersDbContext.Remove(searchedDanceClub);
            _dancersDbContext.SaveChanges();
        }

        public void Update(int id, UpdateDanceClubDto dto)
        {
            var searchedDanceClub = _dancersDbContext
                .DanceClubs
                .FirstOrDefault(r => r.Id == id);
            if (searchedDanceClub is null)
                throw new NotFoundException("DanceClub not found");
            searchedDanceClub.Name = dto.Name;
            searchedDanceClub.Owner = dto.Owner;
            _dancersDbContext.Update(searchedDanceClub);
            _dancersDbContext.SaveChanges();
        }
    }
}
