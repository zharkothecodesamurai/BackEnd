using System.Threading.Tasks;

namespace Seavus.Recipe.Core.DataProvider
{
    public interface IDataProvider
    {
        Task<bool> IsOperational();
    }
}
