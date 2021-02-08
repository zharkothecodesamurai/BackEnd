using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.DataProvider.Edamam.Entities
{
    public class RecipeItemEdamam
    {
        public RecipeItemEdamam()
        {
            Ingredients = new List<Ingredient>();
            TotalNutrient = new NutrientInfo();
            

        }
        
        public string Uri { get; set; }
        public string Label { get; set; }
        public string Image { get; set; }
        public string Source { get; set; }
        public string Url { get; set; }
        public string Yield { get; set; }
        public float  Calories { get; set; }
        public float  TotalWeight { get; set; }
        public float  TotalTime { get; set; }

        public List<string> IngredientLines { get; set; }
        public List<Ingredient> Ingredients { get; set; } 
        public NutrientInfo TotalNutrient{ get; set; }
        public NutrientInfo TotalDaily{ get; set; }
        public List<string> DietLabels { get; set; }
        public List<string> HealtLabels { get; set; }

        
    }
}
