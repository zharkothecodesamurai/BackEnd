using Seavus.Recipe.Core.Entities;
using Seavus.Recipe.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seavus.Recipe.Core.Services
{
    public interface IRecipeService
    {
        //Task<List<RecipeViewModel>> SearchRecipe(string query);
        Task<List<RecipeViewModelDataProvider>> SearchRecipe(string query);
        Task PostRecipes(List<RecipeViewModel> recipeViewModels, string UserId);
        Task<List<RecipeViewModel>> GetRecipesByUserId(Guid Id);

        Task DeleteRecipe(Guid RecipeId);
    }
}
