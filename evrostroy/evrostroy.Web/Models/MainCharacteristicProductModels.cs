using evrostroy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evrostroy.Web.Models
{
    public class MainCharacteristicProductModels
    {
      public IEnumerable<Товары> Products { get; set; }
        public string NameCategory { get; set; }
        public string Route { get; set; }
    }
}