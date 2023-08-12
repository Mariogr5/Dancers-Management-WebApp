using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ptt_api.Models;
using ptt_api.Services;

namespace ptt_api.Controllers
{
    [Route("danceclub")]
    [ApiController]
    [Authorize]
    public class DanceClubController : ControllerBase
    {
        private readonly IDanceClubService _danceClubService;

        public DanceClubController(IDanceClubService danceClubService)
        {
            _danceClubService = danceClubService;
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetAll()
        {
            var DanceClubs = _danceClubService.GetAll();
            return Ok(DanceClubs);
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult GetById([FromRoute]int id)
        {
            var SearchedClub = _danceClubService.GetById(id);
            return Ok(SearchedClub);
        }
        [HttpPost]
        [Authorize(Roles = "Trainer,Admin")]
        public ActionResult CreateDanceClub([FromBody]CreateDanceClubDto dto)
        {
            var createdDanceClubId = _danceClubService.Create(dto);
            return Created($"danceclub/{createdDanceClubId}", null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Trainer,Admin")]
        public ActionResult DeleteDanceCLub([FromRoute]int id)
        {
           _danceClubService.Delete(id);
            return Ok();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Trainer,Admin")]
        public ActionResult UpdateDanceClub([FromRoute]int id, [FromBody]UpdateDanceClubDto dto)
        {
            _danceClubService.Update(id, dto);
            return Ok("Done");
        }
    }
}
