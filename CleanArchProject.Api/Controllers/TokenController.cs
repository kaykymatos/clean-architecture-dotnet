using CleanArchProject.Api.Models;
using CleanArchProject.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticateService;
        private readonly IConfiguration _configuration;
        public TokenController(IAuthenticate authenticateService, IConfiguration configuration)
        {
            _authenticateService = authenticateService;
            _configuration = configuration;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel model)
        {
            var result = await _authenticateService.Authenticate(model.Email, model.Password);
            if (result)
                return Ok(GenerateToken(model));

            ModelState.AddModelError(string.Empty, "Invalid Login attemp.");
            return BadRequest(ModelState);
        }
        private UserToken GenerateToken(LoginModel model)
        {
            var claims = new[]
            {
                new Claim("email",model.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };
            var privateKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"])
                );
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddMinutes(10);

            var token = new JwtSecurityToken
            (
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );
            return new UserToken
            {
                Expiration = expires,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
