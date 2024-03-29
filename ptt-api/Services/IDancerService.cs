﻿using ptt_api.Entities;
using ptt_api.Models;

namespace ptt_api.Services
{
    public interface IDancerService
    {
        IEnumerable<DancerDto> GetAll();
        DancerDto GetById(int id);
        IEnumerable<DancerDto> GetDancersByClubId(int DanceClubId);
        IEnumerable<DancerDto> GetDancersByDanceClass(string danceclass);
        int CreateDancer(int DanceClubId, CreateDancerDto dto);
        void Delete(int id);
        void ChangeDancerClub(int id, int danceClubId);
    }
}