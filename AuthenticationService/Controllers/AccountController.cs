using JWTAuthenticationManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TokenHandlerModels;

namespace AuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;
        public AccountController(JwtTokenHandler jwtTokenHandler)
        {
            _jwtTokenHandler = jwtTokenHandler;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult<AuthenticationResponse?> Authenticate([FromBody] AuthenticationRequest request)
        {
            // verification via the account service
            var user = new UserAccount();
            ////

            var authenticationResponse = _jwtTokenHandler.GenerateJwtToken(user);
            if (authenticationResponse is null) return Unauthorized();
            return authenticationResponse;
        }

        //[HttpPost]
        //[Route("Register")]
        //[AllowAnonymous]
        //public ActionResult<AuthenticationResponse?> Registration([FromBody] AuthenticationRequest request)
        //{
        //}
    }
}