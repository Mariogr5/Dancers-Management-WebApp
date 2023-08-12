using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ptt_api.Models;
using ptt_api.Services;

namespace ptt_api.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController :ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody]RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);
            return Ok();
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDto dto)
        {
            string token = _accountService.GenerateJwtToken(dto);
            return Ok(token);
        }

        [HttpPut("{userid}/role/{roleid}")]
        [Authorize(Roles ="Admin")]
        public ActionResult AssignRole([FromRoute]int userid, [FromRoute]int roleid)
        {
            _accountService.AssignRole(userid, roleid);
            return Ok();
        }
    }
}
