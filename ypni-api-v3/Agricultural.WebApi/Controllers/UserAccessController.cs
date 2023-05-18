using Agricultural.Application.Interfaces.Common;
using Agricultural.WebApi.Controllers.BaseApi;
using Agricultural.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;



namespace Agricultural.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccessController : BaseApiController
    {
        private readonly IJwtTokenManager _jwtTokenManager;
        private readonly ISignInManager _SignManager;
        private readonly IMapper _mapper;

        public UserAccessController(IJwtTokenManager jwtTokenManager, ISignInManager signManager, IMapper mapper)
        {
            _jwtTokenManager = jwtTokenManager;
            _SignManager = signManager;
            _mapper = mapper;

        }
        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] LoginModel loginVm)
        {
            if (loginVm == null)
            {
                var status = new Message
                {
                   
                    code = 800,
                    message = "null object"
                };
                return BadRequest(status);
            }
            var res = await _SignManager.PasswordSiginAsync(loginVm.UserName, loginVm.Password, false, false);
            if (res.Succeeded)
            {
                var result = await ServiceManager.ServiceProviderService.Find(x => x.UserId == res.Data.Id);
                var token = await _jwtTokenManager.GenerateClaimsTokenAsync(res.Data, CancellationToken.None);

                if (token.Succeeded)
                {
                   
                    return Ok(token);

                }
                else return BadRequest(token);
            }
            return BadRequest(res);

        }
        [HttpGet("refreshToken")]
        public async Task<ActionResult<string>> RefreshToken()
        {


            if (Request.Cookies["refreshToken"] != null && Request.Cookies["ExpireTime"] != null)
            {
                var refreshToken = Request.Cookies["refreshToken"];
                var ExpireIn = int.Parse(Request.Cookies["ExpireTime"]);
                //  


                if (string.IsNullOrWhiteSpace(refreshToken))
                {
                    return BadRequest("invalid Refresh Token");
                }

                else if (ExpireIn < DateTime.UtcNow.Hour)
                {
                    return BadRequest("Token Expaired");

                }
                return Ok("goooooooooooood");
            }
            return BadRequest("null value");
        }
        
        //[HttpPost("Logout")]
        //public async Task<IActionResult> Logout()
        //{
        //    _SignManager.Logout();
        //    return RedirectToAction("Login");
        //}

    }
}