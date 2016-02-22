using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evrostroy.Web.Models
{
    public class NavModel
    {
        public List<string> BrandOutDoor { get; set; }
        public List<string> CountryOutDoor { get; set; }

        public List<string> BrandInDoor { get; set; }
        public List<string> CountryInDoor { get; set; }

        public List<string> MaterialInDoor { get; set; }
        public List<string> ColorInDoor { get; set; }

        public List<string> Attention { get; set; }

        public Dictionary<string, string> CategoryD { get; set; }
        public Dictionary<string, string> PodCategoryD { get; set; }
        public List<string> Category { get; set; }
        public List<string> Podcat1 { get; set; }
        public List<string> Podcat2 { get; set; }
      

        //public List<string> RoutProduct { get; set; }

        //public List<string> AllItems { get; set; }
        //public List<int> Index { get; set; }
        //public int Lenght { get; set; }
    }
}