using Microsoft.Extensions.Logging;
using Seavus.Recipe.Core.DataProvider;
using Seavus.Recipe.Core.Services;
using Seavus.Recipe.Core.ViewModels;
using System.Threading.Tasks;

namespace Seavus.Recipe.Api.Services
{
    public class HealthService : IHealthService
    {
        private readonly ILogger _logger;

        private readonly IDataProvider _dataProvider;
        public HealthService(ILogger<HealthService> logger, IDataProvider dataProvider)
        {
            _logger = logger;
            _dataProvider = dataProvider;
        }

        public async Task<HealthViewModel> IsOperational()
        {
            _logger.LogDebug("Executing service status");

            var result = new HealthViewModel
            {
                Services = true,
                DataProvider = await _dataProvider.IsOperational()
            };

            _logger.LogInformation("Services are operational");

            return await Task.FromResult(result);
        }
    }
}
