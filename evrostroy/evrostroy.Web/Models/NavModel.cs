using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evrostroy.Web.Models
{
    public class NavModel
    {
        public List<string> RoutProduct { get; set; }
        public List<string> Attention { get; set; }
        public List<string> AllItems { get; set; }
        public List<int> Index { get; set; }
        public int Lenght { get; set; }
    }
}