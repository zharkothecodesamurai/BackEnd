
using System;
using System.Collections.Generic;
using System.Text;


namespace Seavus.Recipe.Core.ViewModels
{
    public class ShopingListViewModel
    {
        public int Id { get; set; }
        public List<IngridientViewModel> Ingridients { get; set; }
    }
}
