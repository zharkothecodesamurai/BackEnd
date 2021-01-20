using Microsoft.Extensions.Logging;
using Seavus.Recipe.Core.DataProvider;
using System;
using System.Threading.Tasks;

namespace Seavus.Recipe.DataProvider.Edamam
{
    public class EdamamDataProvider : IDataProvider
    {
        private readonly ILogger _logger;
        public EdamamDataProvider(ILogger<EdamamDataProvider> logger)
        {
            _logger = logger;
        }

        public Task<bool> IsOperational()
        {
            _logger.LogDebug("Executing data provider status");

            return Task.FromResult(true);
        }
    }
}
