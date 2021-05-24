using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practice_falconsoft.Models;
using practice_falconsoft.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_falconsoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Autenticar([FromBody] LoginRequest model)
        {
            var loginResponse = _loginService.Auth(model);

            if (loginResponse == null) return BadRequest();

            return Ok(loginResponse);
        }
    }
}
