using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.DataProvider.Edamam.Entities
{
    public class NutrientInfo
    {
        public string Uri { get; set; }
        public string Label { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
    }
}
