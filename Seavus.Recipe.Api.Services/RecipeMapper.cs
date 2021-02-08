using Seavus.Recipe.Core.Entities;
using Seavus.Recipe.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seavus.Recipe.Api.Services
{
   public static class RecipeMapper
    {
        public static List<RecipeItem> ToRecipeItemList(this List<RecipeViewModel> recipeViewModels,Guid userId)
        {
            List<RecipeItem> RecipeItemList = new List<RecipeItem>();

            foreach (var item in recipeViewModels)
            {
                RecipeItemList.Add(new RecipeItem
                {
                    Id=item.Id,
                    Label = item.Name,
                    Calories = item.Calories,
                    ImagePath = item.ImagePath,
                    
                    Ingridients = item.Ingridients.ToIngridientsList(item.Id),
                    UserId = userId
                }); 
            }
            return RecipeItemList;
        }

        public static List<Ingridient> ToIngridientsList(this List<IngridientViewModel> ingridientViewModels, Guid IdfromRecipe)
        {
            List<Ingridient> IngridientsList = new List<Ingridient>();
            foreach (var item in ingridientViewModels)
            {
                IngridientsList.Add(new Ingridient
                {
                    //Id = Guid.NewGuid(),
                    RecipeId = IdfromRecipe,
                    Text = item.Text,
                    Weight = item.Weight,
                    Image = item.Image,

                }); 

            }
            return IngridientsList;
        }

        public static  List<RecipeViewModel> ToRecipeViewModelsList(this List<RecipeItem> recipeItems)
        {
            List<RecipeViewModel> RecipeViewModelList = new List<RecipeViewModel>();
            foreach (var item in recipeItems)
            {
                RecipeViewModelList.Add(new RecipeViewModel
                {
                    Id=item.Id,
                    Name=item.Label,
                    Calories=item.Calories,
                    ImagePath=item.ImagePath,
                    Ingridients=item.Ingridients.ToIngridientsViewModelList(item.Id)
                });


            }
            return RecipeViewModelList;
        }

        public static List<IngridientViewModel> ToIngridientsViewModelList(this List<Ingridient> ingridients, Guid IdfromRecipe)
        {
            List<IngridientViewModel> IngridientsViewModelList = new List<IngridientViewModel>();
            foreach (var item in ingridients)
            {
                IngridientsViewModelList.Add(new IngridientViewModel
                {
                    Id=item.Id,
                    RecipeId = IdfromRecipe,
                    Text = item.Text,
                    Weight = item.Weight,
                    Image = item.Image,

                });

            }
            return IngridientsViewModelList;
        }

        public static List<RecipeViewModel> containsObject(this List<RecipeViewModel> recipeViewModels)
        {
            List<RecipeViewModel> RecipesWithoutGuid = new List<RecipeViewModel>();

            foreach (var item in recipeViewModels)
            {
               var check= item.Ingridients.IngridientsWMGuidCheck();
                if (check.Count>0)
                {
                    RecipesWithoutGuid.Add(new RecipeViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Calories = item.Calories,
                        ImagePath = item.ImagePath,
                        Ingridients = item.Ingridients.IngridientsWMGuidCheck()
                    });
                }
            }

            return RecipesWithoutGuid;
        }

        public static List<IngridientViewModel> IngridientsWMGuidCheck(this List<IngridientViewModel> ingridientViewModels)
        {
            var ingredintsGuidCHeck = new List<IngridientViewModel>();
            for (var i = 0; i < ingridientViewModels.Count; i++)
            {
                if (ingridientViewModels[i].RecipeId == Guid.Empty)
                {
                    
                    ingredintsGuidCHeck.Add(ingridientViewModels[i]);
                }
            }
            return ingredintsGuidCHeck;

        }

        public static List<RecipeViewModel> RecipesFromDbToCheck(this List<RecipeViewModel> recipeViewModelsDB,List<RecipeViewModel> recipesCLient)
        {
            foreach (var item in recipeViewModelsDB)
            {
                recipesCLient.RecipesCheckWithDB(item.Name);
            }
            return recipesCLient;
        }

        public static List<RecipeViewModel> RecipesCheckWithDB(this List<RecipeViewModel> recipeViewModelsClinet, string name)
        {
            var RecipesAfterChecked = new List<RecipeViewModel>();


            foreach (var item in recipeViewModelsClinet)
            {
                if (item.Name != name)
                {
                    RecipesAfterChecked.Add(item);
                }
            }
            return RecipesAfterChecked;
        }


    }
}
