using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Core.Entities
{
    public class Ingridient

    {
        public Ingridient()
        {
            ShopingListIngredients = new List<ShopingListIngredients>();
        }

        
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Weight { get; set; }
        public string Image { get; set; }
        public Guid RecipeId { get; set; }
        public RecipeItem Recipe { get; set; }
        public List<ShopingListIngredients> ShopingListIngredients {get;set;}
      
   
    }
}
