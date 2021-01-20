using Seavus.Recipe.Core.ViewModels;
using System.Threading.Tasks;

namespace Seavus.Recipe.Core.Services
{
    public interface IHealthService
    {
        Task<HealthViewModel> IsOperational();
    }
}
