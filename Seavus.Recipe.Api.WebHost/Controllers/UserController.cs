using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Seavus.Recipe.Core.Services;
using Seavus.Recipe.Core.Shared.Exceptions;
using Seavus.Recipe.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seavus.Recipe.Api.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [AllowAnonymous] // the user can be unauthenticated
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterVievModel registerModel)
        {
            _logger.LogInformation($"Exexuting RegisterMetod");
            Console.WriteLine(registerModel);
            
            try
            {
                await _userService.RegisterUser(registerModel);
                return Ok( $"The user with {registerModel.UserName} is registered");
            }
            catch (UserException e)
            {
                _logger.LogError(e, $"{e.Message }");
                _logger.LogError(e, $"{e.InnerException }");
                return BadRequest(e.Message);
                
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{e.Message }");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured!");
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogingViewModel loginModel)
        {
            _logger.LogInformation($"Exexuting LoggingMetod");
            try
            {
                string token = await _userService.LoginUser(loginModel);
                if (!string.IsNullOrEmpty(token))
                {
                    _logger.LogInformation($"User {loginModel.UserName} is logged");
                }
                return Ok(new { token });
                
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e, $"{e.Message }");
                return StatusCode(StatusCodes.Status401Unauthorized, "The user was not identified!");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{e.Message }");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured!");
            }
        }
    }
}
