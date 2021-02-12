using Seavus.Recipe.Core.Entities;
using Seavus.Recipe.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Api.Services
{
    public static class SlMapper
    {
        public static IngridientViewModel ToIngridientViewModel(this Ingridient ingrident)
        {
            return new IngridientViewModel
            {
                Id = ingrident.Id,
                RecipeId = ingrident.RecipeId,
                Text = ingrident.Text,
                Weight = ingrident.Weight,
                Image = ingrident.Image
            };
        }

        public static Ingridient ToIngridient(this IngridientViewModel ingridentViewModel)
        {
            return new Ingridient
            {
                Id = ingridentViewModel.Id,
                Text = ingridentViewModel.Text,
                Weight = ingridentViewModel.Weight,
                Image = ingridentViewModel.Image,
                RecipeId = ingridentViewModel.RecipeId,

            };
        }

        public static List<ShopingListIngredients> ToSlistfromIvmList(this List<IngridientViewModel> ingridentViewModel, Guid slId)
        {
            var list = new List<ShopingListIngredients>();
            foreach (var item in ingridentViewModel)
            {
                list.Add(new ShopingListIngredients
                {
                    ShopingListId = slId,
                    IngridientsId = item.Id,
                    Ingridient = item.ToIngridient()
                }) ;
            }
            return list;

        }

        public static List<ShopingListIngredients> ToShopingListIngridients(this List<IngridientViewModel> ingridientViewModels, Guid slId)
        {
            var shopingList = new List<ShopingListIngredients>();
            foreach (var item in ingridientViewModels)
            {
                shopingList.Add(new ShopingListIngredients
                {
                    ShopingListId = slId,
                    IngridientsId = item.Id,
                    Ingridient = item.ToIngridient()

                    //=ingridient.ToIngridient(slId, ingridientViewModels)


                });
            }

            return shopingList;




        }

        //public static ShopingList ToSHopingListFromIngridientFF(this Ingridient ingredient, Guid id)
        //{
        //    return new ShopingList
        //    {
        //        Id = id,
        //        ShopingListIngredients = ingredient.ToShopingListIngridientsFromIngridient(id),
        //        User=ingredient.Recipe.User
        //    };
        //}
        public static List<ShopingListIngredients> ToShopingListIngridientsFromIngridient(this Ingridient ingredient,Guid shId,ShopingList sh)
        {
            var list = new List<ShopingListIngredients>();
            list.Add(new ShopingListIngredients
            {
                ShopingListId=shId,
                IngridientsId=ingredient.Id,
                //ShopingList=sh

                //ShopingList=ingredient.ToSHopingListFromIngridientFF(shId)
            });
            return list;
        }
    }
}
