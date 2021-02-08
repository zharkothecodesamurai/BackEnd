using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.DataProvider.Edamam.Entities
{
    class IngridientMappedFromEdamam
    {
        public int RecipeId{ get; set; }
        public string Text { get; set; }
        public string Weight { get; set; }
        public string Image { get; set; }
    }
}
