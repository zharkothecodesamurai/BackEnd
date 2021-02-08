using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Core.Entities
{
    public class RecipeItem
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public float Calories { get; set; }
        public string ImagePath { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public List<Ingridient> Ingridients { get; set; }


    }
}
