using Microsoft.EntityFrameworkCore;
using Seavus.Recipe.Api.DataAccess.Ef.DbContext;
using Seavus.Recipe.Core.DataAccess;
using Seavus.Recipe.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seavus.Recipe.Api.DataAccess.Ef.Repository
{
    public class IngridientRepository : IIngridientRepository
    {
        private readonly RecipeDbContext _recipeDbContext;

        public IngridientRepository(RecipeDbContext recipeDbContext)
        {
            _recipeDbContext = recipeDbContext;
        }
        public async Task<Ingridient> GetIngridientById(Guid Id)
        {
            return await _recipeDbContext.Ingridients
                .Include(x => x.ShopingListIngredients)
                .ThenInclude(x => x.ShopingList)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Update(Ingridient ingridient)
        {
             _recipeDbContext.Ingridients.Update(ingridient);
             await _recipeDbContext.SaveChangesAsync();
        }
    }
}
