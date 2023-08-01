using Microsoft.AspNetCore.Mvc;
using ptt_api.Services;

namespace ptt_api.Controllers
{
    [Route("danceclub")]
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
    }
}
