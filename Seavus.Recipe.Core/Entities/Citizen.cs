using System;
using System.Collections.Generic;
using System.Text;

namespace Seavus.Recipe.Core.Entities
{
    public class Citizen
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }
        public int Height { get; set; }

        public  int Age { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }

       


    }
}
