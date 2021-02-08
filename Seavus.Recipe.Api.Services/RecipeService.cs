using Microsoft.Extensions.Logging;
using Seavus.Recipe.Core.DataAccess;
using Seavus.Recipe.Core.DataProvider;
using Seavus.Recipe.Core.Entities;
using Seavus.Recipe.Core.Services;
using Seavus.Recipe.Core.Shared.Exceptions;
using Seavus.Recipe.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seavus.Recipe.Api.Services
    
{
    public class RecipeService : IRecipeService

    {
        private readonly IDataProvider _dataProvider;
        private readonly IRecipeRepository _recipeRepository;
        private readonly ILogger _logger;
        public RecipeService(ILogger<RecipeService> logger,IDataProvider dataProvider, IRecipeRepository recipeRepository)
        {
            _logger = logger;
            _dataProvider = dataProvider;
            _recipeRepository = recipeRepository;
        }

        public async Task<List<RecipeViewModelDataProvider>> SearchRecipe(string query)
        {
            
            var serviceResult = await _dataProvider.SearchRecipe(query);
          

            //return await Task.FromResult(result);
            return await Task.FromResult(serviceResult);
        }

        public async Task PostRecipes(List<RecipeViewModel> recipesViewModel,string UserId)
        {
            _logger.LogInformation("Executing PostRecipe service");
            Guid guidFormMapping = Guid.Parse(UserId);

            List<RecipeItem> recipeItemsByUserDb =await _recipeRepository.GetByUserId(guidFormMapping);
            List<RecipeViewModel> recipeViewMbyUserDB = recipeItemsByUserDb.ToRecipeViewModelsList();
            
            //proveruvam dali ima vo baza isti takvi
            var CheckedList = recipesViewModel.Where(p=>recipeViewMbyUserDB.All(l=>p.Name!=l.Name)).ToList();
            foreach (var item in CheckedList)
            {
                Console.WriteLine(item.Name);
            }

            if (CheckedList.Count>0)
            {
                //proveruvam dali ima empty guid za recipe po ingridient
                List<RecipeViewModel> ListWithCheckedEmptyGuids = CheckedList.containsObject();
                List<RecipeItem> reuturnedListofRecipesItem = ListWithCheckedEmptyGuids.ToRecipeItemList(guidFormMapping);
                if (ListWithCheckedEmptyGuids.Count > 0)
                {
                    await _recipeRepository.Post(reuturnedListofRecipesItem);
                }
            }
            // tuka treba lista i ako nema recipeId vo INgredients go pustas na maper
           
            //List<RecipeViewModel> ListWithCheckedEmptyGuids = checking.containsObject();

           
            
        }
        public async Task<List<RecipeViewModel>> GetRecipesByUserId(Guid Id)
        {
            _logger.LogInformation("Executing GetRecipeByUserId service");
            List<RecipeItem> recipeItem = await _recipeRepository.GetByUserId(Id);
            List<RecipeViewModel> result = recipeItem.ToRecipeViewModelsList();
            return result;
        }

        public async Task DeleteRecipe(Guid RecipeId)
        {
            _logger.LogInformation("Executing Delete service");
            var recipeDB = await _recipeRepository.GetRecipeByID(RecipeId);
            if (recipeDB == null)
            {
                
                throw new NotFoundException($"Note with id {RecipeId} was not found!");
                //throw new NotFoundException(id);
            }

           await _recipeRepository.Delete(recipeDB);
        }
    }
}
