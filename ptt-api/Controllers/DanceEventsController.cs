using Microsoft.AspNetCore.Mvc;
using ptt_api.Services;

namespace ptt_api.Controllers
{
    [Route("danceevent")]
    public class DanceEventsController : ControllerBase
    {
        private readonly IDanceEventService _danceEventService;

        public DanceEventsController(IDanceEventService danceEventService)
        {
            _danceEventService = danceEventService;
        }
        [HttpGet]
        public ActionResult GetDanceEvents()
        {
            var danceEvents = _danceEventService.GetAll();
            return Ok(danceEvents);
        }
    }
}
