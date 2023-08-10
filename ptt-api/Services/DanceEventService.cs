using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ptt_api.Entities;
using ptt_api.Exceptions;
using ptt_api.Models;
//using DanceEvent = ptt_api.Entities.DanceEvent;

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
