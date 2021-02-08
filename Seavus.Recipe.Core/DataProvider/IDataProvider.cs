using Seavus.Recipe.Core.Entities;
using Seavus.Recipe.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seavus.Recipe.Core.DataProvider
{
    public interface IDataProvider
    {
        Task<bool> IsOperational();

        //Task<List<RecipeItem>> SearchRecipe(string query);

        Task<List<RecipeViewModelDataProvider>> SearchRecipe(string query);
       
    }
}
