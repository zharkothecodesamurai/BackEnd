using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Core.ViewModels
{
    public class RecipeViewModelDataProvider
        
    {
        public RecipeViewModelDataProvider()
        {
            Ingredients = new List<IngridientViewModel>();
        }

        public Guid Id { get; set; }
        public int? UserId { get; set; }
        public string Label { get; set; }
        public float Calories { get; set; }
        public string ImagePath { get; set; }

        public List<IngridientViewModel> Ingredients { get; set; }


    }
}
