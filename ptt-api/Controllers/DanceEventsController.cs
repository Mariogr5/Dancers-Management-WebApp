using Microsoft.AspNetCore.Mvc;
using ptt_api.Models;
using ptt_api.Services;

namespace ptt_api.Controllers
{
    [Route("danceevent")]
    [ApiController]
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
        [HttpGet("{id}")]
        public ActionResult GetDanceEventById([FromRoute]int id)
        {
            var danceEvent = _danceEventService.GetById(id);
            return Ok(danceEvent);
        }
        [HttpPost]
        public ActionResult CreateDanceEvent([FromBody]CreateDanceEventDto dto)
        {
            var newDanceId = _danceEventService.CreateDanceEvent(dto);
            return Created($"danceevent/{newDanceId}", null);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteDanceEvent([FromRoute]int id)
        {
            _danceEventService.DeleteDanceEvent(id);
            return Ok("Delete success!");
        }
    }
}
