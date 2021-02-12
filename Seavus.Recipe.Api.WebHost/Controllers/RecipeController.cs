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
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Seavus.Recipe.Api.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IRecipeService _recipeService;
      

        public RecipeController(ILogger<RecipeController> logger, IRecipeService recipeService)
        {
            _logger = logger;
            _recipeService = recipeService;
  
        }

        [HttpGet]
        public async Task<IActionResult> SearchRecipe(string query)
        {
            _logger.LogInformation("Executing search recipe");

            return Ok(await _recipeService.SearchRecipe(query));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PutRecipes([FromBody] List<RecipeViewModel> recipesVIewModels)
        {

            _logger.LogInformation("Executing putting recipe");

            try
            {
                var accessToken1 = HttpContext.Request.Headers["Authorization"];

                //Console.WriteLine(User.HasClaim(x => x.Type == "UserId"));
                //var userId = User.Claims.First(x => x.Type == "UserId").Value;
                //var tokenDecodedBytes = WebEncoders.Base64UrlDecode(token);


                var userId = User.Claims.First(x => x.Type == "UserId").Value;
                Console.WriteLine(userId);
                Guid guid = Guid.Parse(userId);
                //User userDb = await _userService.GetUserById(guid);

                //if (userDb != null)
                //{


                //}
                await _recipeService.PostRecipes(recipesVIewModels, userId);
                return Ok($"The Recipes have been updated");
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e, $"{e.Message }");
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{e.InnerException}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured!");
            }
        }

        [HttpGet("get")]
        [Authorize]
        public async Task<ActionResult<List<RecipeViewModel>>> GetRecipes()
        {
            try
            {
                _logger.LogInformation("Executing Get recipe");
                var userId = User.Claims.First(x => x.Type == "UserId").Value;
                Guid guid = Guid.Parse(userId);
                List<RecipeViewModel> result = await _recipeService.GetRecipesByUserId(guid);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e, $"{e.InnerException}");
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception e)
            {
                //log
                _logger.LogError(e, $"{e.InnerException}");
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> PutSingleRecipe([FromBody] RecipeViewModel recipeViewModel)
        {
            try
            {
                _logger.LogInformation("Executing Put Single recipe");
             
                var userId = User.Claims.First(x => x.Type == "UserId").Value;
                Guid guid = Guid.Parse(userId);
                await _recipeService.UpdateSingleRecipe(recipeViewModel, guid);
                return Ok($"Resource Updated");
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e, $"{e.InnerException}");
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception e)
            {

                _logger.LogError(e, $"{e.InnerException}");
                return StatusCode(StatusCodes.Status500InternalServerError, e.InnerException);
            }
        }

        [HttpDelete("delete")]
        [Authorize]

        public async Task<IActionResult> DeleteRecipe([FromQuery] Guid Id)
        {
            try
            {
                _logger.LogInformation("Executing Delete recipe");
                Console.WriteLine(Id);
                var userId = User.Claims.First(x => x.Type == "UserId").Value;
                
                await _recipeService.DeleteRecipe(Id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e, $"{e.InnerException}");
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception e)
            {
               
                _logger.LogError(e, $"{e.InnerException}");
                return StatusCode(StatusCodes.Status500InternalServerError, e.InnerException);
            }

        }

    }
}
