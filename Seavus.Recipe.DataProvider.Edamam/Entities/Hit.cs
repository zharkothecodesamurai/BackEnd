using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.DataProvider.Edamam.Entities
{
    public class Hit
    {
        
        public RecipeItemEdamam Recipe { get; set; }

        public bool Bookmarked { get; set; }

        public bool Bought { get; set; }
    }
}
