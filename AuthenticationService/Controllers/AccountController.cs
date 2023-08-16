using AuthenticationService.Services;
using JWTAuthenticationManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TokenHandlerModels;

namespace AuthenticationService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;
        private readonly AccountService _accountService;
        public AccountController(JwtTokenHandler jwtTokenHandler, AccountService accountService)
        {
            _accountService = accountService;
            _jwtTokenHandler = jwtTokenHandler;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult<AuthenticationResponse?> Authenticate([FromBody] AuthenticationRequest request)
        {
            var user = _accountService.GetUserAccountOrDefault(request);
            
            if (user is not null)
            {
                var authenticationResponse = _jwtTokenHandler.GenerateJwtToken(user);
                if (authenticationResponse is null) return Unauthorized();
                return authenticationResponse;
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public ActionResult<AuthenticationResponse?> Registration([FromBody] AuthenticationRequest request)
        {
            return Ok();
        }
    }
}