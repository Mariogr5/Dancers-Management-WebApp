using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ptt_api.Entities;
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
                .OrderBy(x => x.Date)
                .ToList();
            var danceEventsDto = _mapper.Map<IEnumerable<DanceEventDto>>(danceEvents);
            return danceEventsDto;
        }
    }
}
