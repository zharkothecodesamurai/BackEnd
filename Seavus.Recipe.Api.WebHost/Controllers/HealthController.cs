using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Seavus.Recipe.Core.Services;
using System.Threading.Tasks;

namespace Seavus.Recipe.Api.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IHealthService _healthService;

        public HealthController(ILogger<HealthController> logger, IHealthService healthService)
        {
            _logger = logger;
            _healthService = healthService;
        }

        [HttpGet]
        public async Task<IActionResult> CheckHealthStatus()
        {
            _logger.LogInformation("Executing health status");

            return Ok(await _healthService.IsOperational());
        }
    }
}
