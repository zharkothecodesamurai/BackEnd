using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.DataProvider.Edamam.Entities
{
    public class EdamResponce
    {
        public string Q { get; set; }
        public int Form { get; set; }
        public int To { get; set; }
        public int Count { get; set; }
        public bool More { get; set; }

        public List<Hit> Hits { get; set; }

    }
}
