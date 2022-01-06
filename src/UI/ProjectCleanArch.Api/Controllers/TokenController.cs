using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectCleanArch.Api.Model;
using ProjectCleanArch.Domain.Auth;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCleanArch.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate authentication, IConfiguration configuration)
        {
            _authentication = authentication ?? throw new ArgumentNullException(nameof(authentication));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("loginu-ser")]
        public async Task<ActionResult<UserToken>> Login(LoginResquest login)
        {
            var result = await _authentication.Autenticate(login.Email, login.Password);

            if (result)
            {
                return Ok(GenerateToken(login));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt (password must be strong");

                return BadRequest();
            }
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Authorize]
        [Route("registers-user")]
        public async Task<IActionResult> Register(LoginResquest register)
        {
            var result = await _authentication.RegisterUser(register.Email, register.Password);

            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt (password must be strong");

                return BadRequest();
            }

            return Ok($"User {register.Email} create successfully");
        }

        private UserToken GenerateToken(LoginResquest login)
        {
            //Declarações do usuário
            var claims = new[]
            {
                new Claim("email", login.Email),
                new Claim("valorTest", "Aqui eu poderia colocar qualquer valor"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //Gerar chave privada para assinar token
            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            //Gerar assinatura digital do token
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            //Definir tempo de expiração do token
            var experition = DateTime.UtcNow.AddMinutes(10);

            //Gerar o token
            var token = new JwtSecurityToken(
                //Emissor
                issuer: _configuration["Jwt:Issuer"],
                //Audiencia
                audience: _configuration["Jwt:Audience"],
                //Claims
                claims: claims,
                //Data de Expiração
                expires: experition,
                //Assinatura digital
                signingCredentials: credentials);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Experition = experition
            };
        }
    }
}
