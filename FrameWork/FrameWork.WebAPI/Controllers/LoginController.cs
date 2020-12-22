using FrameWork.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;
using WebServices;

namespace FrameWork.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("index")]
        public LoginStatusResult Index([FromQuery] LoginParams param)
        {
            var ls = new LoginService();
            if (ls.Login(param.Username, param.Pwdmd5, out string token))
            {
                //cookies
                new CookiesHelper(HttpContext).SetCORSCookieValue(LoginService.AccountUserTokenCookieKey, token);
                return new LoginStatusResult() { Status = "success", Token = token };
            }
            else
            {
                return new LoginStatusResult() { Status = "failure", Token = token };
            }
        }

        [HttpGet]
        [Route("IsLogin")]
        public IsLoginResult IsLogin()
        {
            var token = new CookiesHelper(HttpContext).GetCookieValue("AccountUser");
            return new IsLoginResult()
            {
                IsLogin = new LoginService().IsTokenAvalible(token),
                token = token
            };
        }
    }
}
