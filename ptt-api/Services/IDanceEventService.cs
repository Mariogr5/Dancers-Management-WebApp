using ptt_api.Models;

namespace ptt_api.Services
{
    public interface IDanceEventService
    {
        IEnumerable<DanceEventDto> GetAll();
    }
}