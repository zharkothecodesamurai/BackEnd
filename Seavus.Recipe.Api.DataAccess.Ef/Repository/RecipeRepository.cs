using Microsoft.EntityFrameworkCore;
using Seavus.Recipe.Api.DataAccess.Ef.DbContext;
using Seavus.Recipe.Core.DataAccess;
using Seavus.Recipe.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seavus.Recipe.Api.DataAccess.Ef.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDbContext _recipeDbContext;

        public RecipeRepository(RecipeDbContext recipeDbContext)
        {
            _recipeDbContext = recipeDbContext;
        }

        public async Task Delete(RecipeItem entity)
        {
            _recipeDbContext.Recipes.Remove(entity);
            await _recipeDbContext.SaveChangesAsync();

        }

        public async Task<List<RecipeItem>> GetByUserId(Guid userId)
        {

            return await _recipeDbContext.Recipes
                .Include(x => x.User)
                .Include(x => x.Ingridients)
                .ThenInclude(x => x.ShopingListIngredients)
                .ThenInclude(x => x.Ingridient)
                .Where(x => x.UserId == userId).ToListAsync();

           
        }

        public async Task<RecipeItem> GetRecipeByID(Guid Id)
        {
            RecipeItem recipe =_recipeDbContext.Recipes.Include(x => x.User)
                .Include(x => x.Ingridients)
                .FirstOrDefault(x => x.Id == Id);
            return await Task.FromResult(recipe);
        }

        public async Task Post(List<RecipeItem> entities)
        {
          entities.ForEach(entitie =>
            {
               _recipeDbContext.Recipes.AddAsync(entitie);
            });
            await _recipeDbContext.SaveChangesAsync();

            

        }
    }
}
