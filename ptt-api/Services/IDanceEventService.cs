using ptt_api.Models;

namespace ptt_api.Services
{
    public interface IDanceEventService
    {
        IEnumerable<DanceEventDto> GetAll();
        DanceEventDto GetById(int id);
        int CreateDanceEvent(CreateDanceEventDto dto);
        void DeleteDanceEvent(int id);
        int CreateDanceCategory(int eventid, CreateCategoryDto dto);
    }
}