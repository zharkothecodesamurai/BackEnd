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
    public class ShoppingListController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IShopingListService _slService;
        public ShoppingListController(ILogger<ShoppingListController> logger, IShopingListService slService)
        {
            _logger = logger;
            _slService = slService;
        }

        [HttpGet("get")]
        [Authorize]
        public async Task<ActionResult<ShopingListViewModel>> GetShoppingList()
        {
            try
            {
                
                _logger.LogInformation("Executing Get Shopping List");
                var userId = User.Claims.First(x => x.Type == "UserId").Value;
                Guid UserId = Guid.Parse(userId);
             
                return Ok(await _slService.GetSlByUserId(UserId));
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

        [HttpPost("post")]
        [Authorize]
        public async Task<IActionResult> PostShoppingList([FromBody] List<IngridientViewModel> ingridientsFromhopingList)
        {
            try
            {

                _logger.LogInformation("Executing Post Shopping List");
                var userId = User.Claims.First(x => x.Type == "UserId").Value;
                Guid UserId = Guid.Parse(userId);
                await _slService.PostShopingListIngredients(ingridientsFromhopingList, UserId);
                return Ok("Shoping list has been added");
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

        [HttpPut("remove/ingridient/{Id}")]
        [Authorize]
        public async Task<IActionResult> RemoveIngridientFromShopingList(Guid Id)
        {
            try
            {

                _logger.LogInformation("Executing RemoveIngridientFromShopingList");
                var userId = User.Claims.First(x => x.Type == "UserId").Value;
                Guid UserId = Guid.Parse(userId);
                await _slService.DelteSingleIngredientOfShopingList(Id,UserId);
                return StatusCode( StatusCodes.Status204NoContent,"Ingredient Removed From ShopingList");
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
    }
}
