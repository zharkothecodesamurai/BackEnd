using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Core.Entities
{
    public class ShopingList
    {


        public Guid Id { get; set; }
        //public int UserId { get; set; }

        public User User { get; set; }
        public List<ShopingListIngredients> ShopingListIngredients { get; set; }
    }
}
