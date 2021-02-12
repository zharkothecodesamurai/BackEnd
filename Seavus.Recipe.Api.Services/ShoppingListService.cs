using Microsoft.Extensions.Logging;
using Seavus.Recipe.Core.DataAccess;
using Seavus.Recipe.Core.Entities;
using Seavus.Recipe.Core.Services;
using Seavus.Recipe.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seavus.Recipe.Api.Services
{
    public class ShoppingListService : IShopingListService
    {
        private readonly ILogger _logger;
        private readonly IShopingListRepository _shopingListRepository;
        private readonly IUserRepository _userRepository;
        

        public ShoppingListService(ILogger<ShoppingListService> logger, IShopingListRepository shopingListRepository, IUserRepository userRepository)
        {
           _logger = logger;
           _shopingListRepository = shopingListRepository;
            _userRepository = userRepository;
          
        }

        public async Task<ShopingListViewModel> GetSlByUserId(Guid UserId)
        {
            _logger.LogInformation($"Executing GetSlByUserId for {UserId} method");

            ShopingList slDB = await _shopingListRepository.GetSlByUserId(UserId);
            var check = slDB.ShopingListIngredients.Select(x => x).Distinct().ToList();
            List<IngridientViewModel> ListOfIngridients = new List<IngridientViewModel>();
            foreach (var item in check)
            {
                ListOfIngridients.Add(item.Ingridient.ToIngridientViewModel());
            }
            ShopingListViewModel shopingListViewM = new ShopingListViewModel
            {
                Id = slDB.Id,
                Ingridients = ListOfIngridients
            };
            return await Task.FromResult(shopingListViewM);
        }

        public async Task PostShopingListIngredients(List<IngridientViewModel> ingredients, Guid ShopingListId)
        {
            _logger.LogInformation($"Executing PostShopingListIngredients");
            User UserDb = await _userRepository.GetUserById(ShopingListId);
            ShopingList ShopingListObj = UserDb.ShopingList;
            List<Ingridient> ingridinetsofRecipebyUserDb = UserDb.Recipes.SelectMany(x => x.Ingridients).ToList();
             var ing= UserDb.Recipes.SelectMany(x => x.Ingridients.SelectMany(x => x.ShopingListIngredients)).ToList();
            var list = new List<List<Ingridient>>();
            foreach (var item in ingredients)
            {
                list.Add(UserDb.Recipes.SelectMany(x => x.Ingridients.Where(l => l.Id == item.Id)).ToList());
            }
            List<Ingridient> ListIngridientsByDBFromClient = list.SelectMany(x => x).ToList();
            //ova za da napravam sporedba so size na db i sto pustam od request
            if (UserDb.ShopingList.ShopingListIngredients.Count > 0)
            {
                List<Ingridient> UserDbShopingListIngridients = UserDb.ShopingList.ShopingListIngredients.Select(x=>x.Ingridient).Distinct().ToList();
                //List<Ingridient> IngridentsList = new List<Ingridient>();
                //foreach (var item in UserDbShopingListIngridients)
                //{
                //    IngridentsList.Add(item.Ingridient);
                //}
                List<Ingridient> CheckForDuplicatesFromDb = ListIngridientsByDBFromClient.Where(p => UserDbShopingListIngridients.All(l => p.Id != l.Id)).ToList();
                if (CheckForDuplicatesFromDb.Count > 0)
                {
                    //List<Ingridient> UniqueIngridients = CheckForDuplicatesFromDb.Where(p => ingredients.All(l => p.Id != l.Id)).ToList();
                    
                    //if (UniqueIngridients.Count>0)
                    //{
                        //List<Ingridient> UniqueIngridients = UniqueIngridientsViewModels.ToIngridientsListWithRecipeId();
                        foreach (var item in CheckForDuplicatesFromDb)
                        {
                            item.ShopingListIngredients = item.ToShopingListIngridientsFromIngridient(ShopingListId, ShopingListObj);
                        }
                        foreach (var item in CheckForDuplicatesFromDb)
                        {
                            ing.Add(new ShopingListIngredients
                            {
                                ShopingListId = ShopingListId,
                                   IngridientsId = item.Id,
                                   Ingridient = item
                            });
                            //UserDb.ShopingList.ShopingListIngredients.Add(new ShopingListIngredients
                            //{
                            //    ShopingListId = ShopingListId,
                            //    IngridientsId = item.Id,
                            //    Ingridient = item


                            //});
                        }
                        var check = UserDb;

                        await _userRepository.Update(UserDb);
                    }
                   
               }
                
            
            else
            {
                foreach (var item in ListIngridientsByDBFromClient)
                {
                    item.ShopingListIngredients = item.ToShopingListIngridientsFromIngridient(ShopingListId, ShopingListObj);
                }
               
                //var check = UserDb.Recipes.Select(x => x.Ingridients.Where(l => l.Id == x.Id)).ToList();
                //List<Ingridient> IngridientsList = ingredients.ToIngridientsListWithRecipeId();
                //foreach (var item in ListIngridientsByDB)
                //{
                //    item.ShopingListIngredients = item.ToShopingListIngridientsFromIngridient(ShopingListId, ShopingListObj);
                //}
                foreach (var item in ListIngridientsByDBFromClient)
                {
                    ing.Add(new ShopingListIngredients
                    {
                        ShopingListId = ShopingListId,
                        IngridientsId = item.Id,
                        Ingridient = item
                    });
                    //UserDb.ShopingList.ShopingListIngredients.Add(new ShopingListIngredients
                    //{

                    //    ShopingListId = ShopingListId,
                    //    IngridientsId = item.Id,
                    //    Ingridient = item


                    //});
                }
                var check = UserDb;

                await _userRepository.Update(UserDb);
            }

            ///
            //var addingList = new List<List<Ingridient>>();
            //foreach (var item in ingredients)
            //{
            //    addingList.Add(UserDb.Recipes.SelectMany(x => x.Ingridients.Where(y => y.Id == item.Id)).ToList());
            //}
            //vaka user kje updatiram
            //var ShopingListIngredients = ingredients.ToShopingListIngridients(ShopingListId);
            //UserDb.ShopingList.ShopingListIngredients = ShopingListIngredients;

            //List<Ingridient> ListWithIngridientsForSL = addingList.SelectMany(x => x).ToList();
            //tuka im dodavam Id od keys




        }
    }
}
