using Seavus.Recipe.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seavus.Recipe.Core.Services
{
    public interface IShopingListService
    {
        Task<ShopingListViewModel> GetSlByUserId(Guid UserId);

        Task PostShopingListIngredients(List<IngridientViewModel> ingridients, Guid ShopingListID);

    }
}
