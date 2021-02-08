using Seavus.Recipe.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Seavus.Recipe.Core.DataAccess
{
    public interface IShopingListRepository
    {
        Task<ShopingList> GetSlByUserId(Guid UserId);
        Task Update(ShopingList entity);
    }
}
