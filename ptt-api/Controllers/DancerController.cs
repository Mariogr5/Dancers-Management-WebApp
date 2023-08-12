using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ptt_api.Models;
using ptt_api.Services;

namespace ptt_api.Controllers
{
    [Route("dancer")]
    [ApiController]
    public class DancerController : ControllerBase
    {
        private readonly IDancerService _dancerService;

        public DancerController(IDancerService dancerService)
        {
            _dancerService = dancerService;
        }
        [HttpGet]
        public ActionResult GetAllDancers()
        {
            var allDancers = _dancerService.GetAll();
            return Ok(allDancers);
        }
        [HttpGet("{id}")]
        public ActionResult GetDancerById([FromRoute]int id)
        {
            var searchedDancer = _dancerService.GetById(id);
            return Ok(searchedDancer);
        }
        [HttpGet("danceclub/{DanceClubId}")]
        public ActionResult GetDancersByClubId([FromRoute] int DanceClubId)
        {
            var searchedDancers = _dancerService.GetDancersByClubId(DanceClubId);
            return Ok(searchedDancers);
        }
        [HttpPost("danceclub/{DanceClubId}")]
        [Authorize(Roles = "Trainer,Admin")]
        public ActionResult CreateDancer([FromRoute]int DanceClubId, [FromBody]CreateDancerDto dto)
        {
            var createdDancerId = _dancerService.CreateDancer(DanceClubId,dto);
            return Created("danceclub/dancer/{createdDancerId}", null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Trainer,Admin")]
        public ActionResult DeleteDancer([FromRoute]int id)
        {
            _dancerService.Delete(id);
            return Ok();
        }
        [HttpPut("{id}/dancepartner/{PartnerId}")]
        [Authorize(Roles = "Trainer,Admin")]
        public ActionResult PairtheDancers(int id, int PartnerId)
        {
            _dancerService.PairtheDancers(id, PartnerId);
            return Ok("Done");
        }
        [HttpPut("{id}/newclub/{danceClubId}")]
        [Authorize(Roles = "Trainer,Admin")]
        public ActionResult ChangeDancerClub([FromRoute]int id, [FromRoute]int danceClubId)
        {
            _dancerService.ChangeDancerClub(id, danceClubId);
            return Ok();
        }
    }
}
