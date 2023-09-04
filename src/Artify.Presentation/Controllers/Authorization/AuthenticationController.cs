using Artify.API.Filters;
using Artify.Entities.DTO;
using Artify.Entities.DTO.Authorization;
using Artify.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Artify.Presentation.Controllers.Authorization
{
    [Route("api/auth")]
    [ApiController]

    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IServiceManager _service;


        public AuthenticationController(IServiceManager service, ILoggerFactory logger)
        {
            _service = service;
            _logger = logger.CreateLogger<AuthenticationController>();
        }

        [HttpPost("registration")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto
            userForRegistrationDto)
        {
            var result = await _service.AuthenticationService.RegisterUser(userForRegistrationDto);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _service.AuthenticationService.ValidateUser(user))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

            var tokenDto = await _service.AuthenticationService
                .CreateToken(populateExp: true);

            return Ok(new AuthResponseDto
            {
                IsAuthSuccessful = true,
                Token = tokenDto.Token,
                RefreshToken = tokenDto.RefreshToken
            });
        }
    }
}
