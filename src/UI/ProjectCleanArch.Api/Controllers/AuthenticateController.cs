using Microsoft.AspNetCore.Mvc;
using ProjectCleanArch.Api.Model;
using ProjectCleanArch.Domain.Auth;
using System.Threading.Tasks;

namespace ProjectCleanArch.Api.Controllers
{
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticate _authentication;

        public AuthenticateController(IAuthenticate authentication)
        {
            _authentication = authentication;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest register)
        {
            var result = await _authentication.RegisterUser(register.Email, register.Password);

            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt (password must be strong");

                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginResquest login)
        {
            var result = await _authentication.Autenticate(login.Email, login.Password);

            if (result)
            {
                if (string.IsNullOrEmpty(login.ReturnUrl))
                {
                    return Ok("Return index");
                }

                return Ok(login.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt (password must be strong");

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authentication.Logout();

            return Ok("Logout finish");
        }
    }
}
