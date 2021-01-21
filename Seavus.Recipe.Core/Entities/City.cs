using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Core.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string CityCodeA2 { get; set; }
        public string CityName { get; set; }

        public int Population { get; set; }
        public List<Citizen> Citizens { get; set; }
    }
}
