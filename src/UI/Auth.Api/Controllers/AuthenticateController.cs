using Auth.Api.Models.Request;
using Auth.Api.Models.Response;
using Auth.Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController: ControllerBase
    {
        private readonly IUserService _service;
        private readonly IConfiguration _configuration;

        public AuthenticateController(IUserService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody]RegisterRequest register)
        {
            var dto = register.MappingToDto();
            var result = await _service.Create(dto);

            if (result == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt");

                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("user-token")]
        public async Task<ActionResult> UserToken([FromBody]RegisterRequest register)
        {
            var result = await _service.Autenticate(register.Email, register.Password);

            if (result == null)
            {
                ModelState.AddModelError(string.Empty, "Not found register");
                return NotFound("Not found register");
            }

            var token = GenerateToken(result.Email, result.Password);

            if (token == null)
            {
                return UnprocessableEntity("Error in generater token");
            }

            return Ok(token);
        }

        private TokenResponse GenerateToken(string email, string pass) 
        {
            var claims = new[]
            {
                new Claim("email", email),
                new Claim("pass", pass),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var experition = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["Jwt:ExperiationInMinutes"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: experition,
                signingCredentials: credentials);

            return new TokenResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Experition = experition
            };
        }
    }
}
