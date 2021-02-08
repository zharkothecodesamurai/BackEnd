using Seavus.Recipe.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.DataProvider.Edamam.Entities
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


        public static List<IngridientViewModel> ToListIngridietsFromList (this List<Ingredient> Ingridients )
        {
            var list = new List<IngridientViewModel>();
            foreach (var item in Ingridients)
            {
                list.Add(new IngridientViewModel
                {
                    
                    Text=item.Text,
                    Weight=item.Weight,
                    Image=item.Image
                });
            }
            return list;
        }

    }
}
