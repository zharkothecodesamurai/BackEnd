using System;
using System.Collections.Generic;

namespace Seavus.Recipe.Core.ViewModels
{
    public class RecipeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Calories { get; set; }
        public string ImagePath { get; set; }

        public List<IngridientViewModel> Ingridients { get; set; }

    }
}
