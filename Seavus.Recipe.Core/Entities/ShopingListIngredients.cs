using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Core.Entities
{
    public class ShopingListIngredients
    {
        public int Id { get; set; }
        public Guid ShopingListId { get; set; }
        public ShopingList ShopingList { get; set; }
        public Guid IngridientsId { get; set; }
        public Ingridient Ingridient { get; set; }
    }
}
