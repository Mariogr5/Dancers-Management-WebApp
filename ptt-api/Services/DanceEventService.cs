﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ptt_api.Entities;
using ptt_api.Exceptions;
using ptt_api.Models;

namespace ptt_api.Services
{
    public class DanceEventService : IDanceEventService
    {
        private readonly DancersDbContext _dbContext;
        private readonly IMapper _mapper;

        public DanceEventService(DancersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<DanceEventDto> GetAll()
        {
            var danceEvents = _dbContext
                .DanceEvents
                .Include(r =>r.DanceCompetitionCategories)
                    .ThenInclude(r => r.ListofPairs)
                .OrderBy(x => x.Date)
                .ToList();
            var danceEventsDto = _mapper.Map<IEnumerable<DanceEventDto>>(danceEvents);
            return danceEventsDto;
        }

        public DanceEventDto GetById(int id)
        {
            var danceEvent = _dbContext
                .DanceEvents
                .Include(r => r.DanceCompetitionCategories)
                    .ThenInclude(r => r.ListofPairs)
                .FirstOrDefault(x => x.Id == id);
            if (danceEvent is null)
                throw new NotFoundException("Dance Event not found");
            var danceEventDto = _mapper.Map<DanceEventDto>(danceEvent);
            return danceEventDto;
        }

        public int CreateDanceEvent(CreateDanceEventDto dto)
        {
            var newDanceEvent = _mapper.Map<DanceEvent>(dto);
            _dbContext.Add(newDanceEvent);
            _dbContext.SaveChanges();
            return newDanceEvent.Id;
        }


        public int CreateDanceCategory(int eventid, CreateCategoryDto dto)
        {
            var danceevent = _dbContext.DanceEvents.FirstOrDefault(r => r.Id == eventid);
            if (danceevent is null)
                throw new BadRequestException("Event not found");
            var newcategory = _mapper.Map<DanceCompetitionCategory>(dto);
            newcategory.DanceEventId = danceevent.Id;
            newcategory.ListofPairs = new List<DancePair>();
            _dbContext.DanceCompetitionCategories.Add(newcategory);
            _dbContext.SaveChanges();
            return danceevent.Id;
        }

        public void DeleteDanceCategory(int categoryid)
        {
            var dancecategory = _dbContext.DanceCompetitionCategories.FirstOrDefault(r => r.Id == categoryid);
            if (dancecategory is null)
                throw new NotFoundException("Category not found");
            _dbContext.DanceCompetitionCategories.Remove(dancecategory);
            _dbContext.SaveChanges();
        }

        public void DeleteDanceEvent(int id)
        {
            var deletedEvent = _dbContext
                .DanceEvents
                .FirstOrDefault(r => r.Id == id);
            if (deletedEvent is null)
                throw new NotFoundException("Dance Event not found");
            _dbContext.DanceEvents.Remove(deletedEvent);
            _dbContext.SaveChanges();
        }
    }
}
