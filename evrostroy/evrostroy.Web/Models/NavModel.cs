using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evrostroy.Web.Models
{
    public class NavModel
    {
        public IEnumerable<string> Categories { get; set; }
        public List<string> PodCategoriesF { get; set; }
        public List<string> PodCategoriesS { get; set; }
        public List<string> Brand {get; set; }
        public List<string> Color { get; set; }
        public List<string> Material { get; set; }
        public List<string> Contry { get; set; }
        public List<string> AllItems { get; set; }
        public List<string> AnotherItems { get; set; }
    }
}