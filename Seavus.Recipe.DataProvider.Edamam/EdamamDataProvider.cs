using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Seavus.Recipe.Core.DataProvider;
using Seavus.Recipe.Core.ViewModels;
using Seavus.Recipe.DataProvider.Edamam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

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

        public async Task<bool> IsOperational()
        {
            _logger.LogDebug("Executing data provider status");

            return await Task.FromResult(true);
        }

        public async Task<List<RecipeViewModelDataProvider>> SearchRecipe(string query) {
            //var result = new List<string>();
            //return await Task.FromResult(result);

            
            
            HttpClient httpClient = new HttpClient();
            string url = $"https://api.edamam.com/search?q={query}&app_id=bf5bad45&app_key=9d3abac91e6f19663b088521f42ea4ec";
            System.Console.WriteLine(url);
            HttpResponseMessage responseMessage = httpClient.GetAsync(url).Result;

            string responseBody = responseMessage.Content.ReadAsStringAsync().Result;
            string response = await Task.FromResult(responseBody);
            System.Console.WriteLine(response);

            EdamResponce ResponceFromEdmam = JsonConvert.DeserializeObject<EdamResponce>(response);

            EdamResponce finalRespond = ResponceFromEdmam;
            System.Console.WriteLine(finalRespond);

            List<RecipeItemEdamam> ResponseHit = new List<RecipeItemEdamam>();

            foreach (var item in finalRespond.Hits)
            {
                ResponseHit.Add(item.Recipe);
                System.Console.WriteLine(item.Recipe.Label);
            }

            List<RecipeViewModelDataProvider> recipeVmDataProvider = new List<RecipeViewModelDataProvider>();

            foreach (var item in ResponseHit)
            {

                recipeVmDataProvider.Add(new RecipeViewModelDataProvider
                {
                    Id = Guid.NewGuid(),
                    Label = item.Label,
                    Calories = item.Calories,
                    ImagePath = item.Image,
                    //Ingredients = (List<IngridientViewModel>)item.Ingredients.Select(x => x.ToIngridientViewModel())
                    Ingredients = item.Ingredients.ToListIngridietsFromList()
                });
            }
            return await Task.FromResult(recipeVmDataProvider);
        }
    }
}


