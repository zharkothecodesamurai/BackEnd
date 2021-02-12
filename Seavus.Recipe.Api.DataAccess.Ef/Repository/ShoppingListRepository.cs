using Microsoft.EntityFrameworkCore;
using Seavus.Recipe.Api.DataAccess.Ef.DbContext;
using Seavus.Recipe.Core.DataAccess;
using Seavus.Recipe.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seavus.Recipe.Api.DataAccess.Ef.Repository
{
    public class ShoppingListRepository : IShopingListRepository
    {
        private readonly RecipeDbContext _recipeDbContext;

        public ShoppingListRepository(RecipeDbContext recipeDbContext)
        {
            _recipeDbContext = recipeDbContext;
        }

        public async Task<ShopingList> GetSlByUserId(Guid UserId)
        {
          return await _recipeDbContext.ShoppingList
                        .Include(x => x.User)
                        .Include(x=>x.ShopingListIngredients)
                        .ThenInclude(x=>x.Ingridient)
                        .FirstOrDefaultAsync(x=>x.Id==UserId);

           
        }

        public async Task Update(ShopingList entity)
        {
             _recipeDbContext.Add(entity);
            await _recipeDbContext.SaveChangesAsync();

            

        }

    
    }
}
