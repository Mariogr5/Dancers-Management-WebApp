using Microsoft.AspNetCore.Mvc;
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

    }
}
