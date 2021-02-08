using Seavus.Recipe.Core.ViewModels;
using Seavus.Recipe.DataProvider.Edamam.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Api.Mappers
{
    public static class IngredientMapper
    {
        public static IngridientViewModel ToIngridientViewModel(this Ingredient Ingridient)
        {
            return new IngridientViewModel
            {
                Text = Ingridient.Text,
                Weight = Ingridient.Weight,
                Image = Ingridient.Image

            };
        }
    }
}
