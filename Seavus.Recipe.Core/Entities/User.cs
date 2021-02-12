using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Core.Entities
{
    public class User
    {
        public User()
        {
            ShopingList = new ShopingList();
        }

        public static object Claims { get; set; }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
      

        public List<RecipeItem> Recipes { get; set; }

        public ShopingList ShopingList { get; set; }
    }
}
