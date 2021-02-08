using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.DataProvider.Edamam.Entities
{
    class RecipeMappedFromEdamam
    {
        public RecipeMappedFromEdamam()
        {
            Ingredients = new List<Ingredient>();
          
        }

        
        public int Id { get; set; }
        public string Label { get; set; }
        public string Image { get; set; }
  
        public float Calories { get; set; }
      

        public List<string> IngredientLines { get; set; }
        public List<Ingredient> Ingredients { get; set; }

    }
}
