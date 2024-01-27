using CleanArchProject.Api.Models;
using CleanArchProject.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticate _authenticateService;
        public UserController(IAuthenticate authenticateService)
        {
            _authenticateService = authenticateService;
        }
        [HttpPost("CreateUser")]
        [AllowAnonymous]
        public async Task<ActionResult> CreateUser([FromBody] LoginModel model)
        {
            var result = await _authenticateService.RegisterUser(model.Email, model.Password);
            if (result)
                return Ok($"User {model.Email} was created sucessfuly!");

            ModelState.AddModelError(string.Empty, "Invalid Login attemp.");
            return BadRequest(ModelState);
        }
    }
}
