using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Core.ViewModels
{
    public class IngridientViewModel
    {
        
        
       public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public string Text { get; set; }
        public string Weight { get; set; }
        public string Image { get; set; }

    }
}
