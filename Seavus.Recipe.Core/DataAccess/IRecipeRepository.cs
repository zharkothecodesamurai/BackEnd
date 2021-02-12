using Seavus.Recipe.Core.Entities;
using Seavus.Recipe.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seavus.Recipe.Core.DataAccess
{
    public interface IRecipeRepository
    {
        Task<List<RecipeItem>> GetByUserId(Guid userId);
        Task Post(List<RecipeItem> entities);

        Task Delete(RecipeItem entity);
        Task<RecipeItem> GetRecipeByID(Guid Id);
        Task Update(RecipeItem recipeDb);
    }
}
