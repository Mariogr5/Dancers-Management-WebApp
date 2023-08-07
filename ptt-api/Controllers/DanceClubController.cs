using Microsoft.AspNetCore.Mvc;
using ptt_api.Models;
using ptt_api.Services;

namespace ptt_api.Controllers
{
    [Route("danceclub")]
    [ApiController]
    public class DanceClubController : ControllerBase
    {
        private readonly IDanceClubService _danceClubService;

        public DanceClubController(IDanceClubService danceClubService)
        {
            _danceClubService = danceClubService;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var DanceClubs = _danceClubService.GetAll();
            return Ok(DanceClubs);
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute]int id)
        {
            var SearchedClub = _danceClubService.GetById(id);
            if(SearchedClub == null)
                return NotFound();
            return Ok(SearchedClub);
        }
        [HttpPost]
        public ActionResult CreateDanceClub([FromBody]CreateDanceClubDto dto)
        {
            var createdDanceClubId = _danceClubService.Create(dto);
            return Created($"danceclub/{createdDanceClubId}", null);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteDanceCLub([FromRoute]int id)
        {
            var result = _danceClubService.Delete(id);
            if (!result)
                return NotFound();
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateDanceClub([FromRoute]int id, [FromBody]UpdateDanceClubDto dto)
        {
            var result = _danceClubService.Update(id, dto);
            if (!result)
                return NotFound();
            return Ok("Done");
        }
    }
}
