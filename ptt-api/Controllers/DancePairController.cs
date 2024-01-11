using Microsoft.AspNetCore.Mvc;
using ptt_api.Models;
using ptt_api.Services;

namespace ptt_api.Controllers
{
    [Route("dancepair")]
    [ApiController]
    public class DancePairController : ControllerBase
    {
        private readonly IDancePairService _dancepairservice;

        public DancePairController(IDancePairService dancePairService)
        {
            _dancepairservice = dancePairService;
        }

        [HttpGet]
        public ActionResult GetAllDancePairs()
        {
            var alldancepairs = _dancepairservice.GetAll();
            return Ok(alldancepairs);
        }

        [HttpGet("{id}")]
        public ActionResult GetPairById(int id)
        {
            var pair = _dancepairservice.GetPairById(id);
            return Ok(pair);
        }

        [HttpPut("{dancepairid}/competition/{dancecompetitioncategoryid}")]
        public ActionResult AddDancePairToDanceCompetitionCategory([FromRoute] int dancecompetitioncategoryid, [FromRoute] int dancepairid)
        {
            _dancepairservice.AddDancePairToDanceCompetitionCategory(dancecompetitioncategoryid, dancepairid);
            return Ok();
        }

        [HttpPost("{id}/partner/{dancepartnerid}")]
        public ActionResult PairtheDancers([FromRoute]int id, [FromRoute]int dancepartnerid, [FromBody]CreateDancePairDto dto)
        {
            var newdancepair = _dancepairservice.PairtheDancers(id, dancepartnerid, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePair([FromRoute]int id)
        {
            _dancepairservice.DeletePair(id);
            return Ok();
        }
    }
}
