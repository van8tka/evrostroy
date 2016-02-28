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
      

        public List<string> BrandInDoor { get; set; }
    

        public List<string> Attention { get; set; }

        public Dictionary<string, string> CategoryD { get; set; }
        public Dictionary<string, string> PodCategoryD { get; set; }
        public List<string> Category { get; set; }
        public List<string> Podcat1 { get; set; }
        public List<string> Podcat2 { get; set; }
   }
}