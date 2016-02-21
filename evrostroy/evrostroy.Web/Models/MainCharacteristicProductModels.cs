using evrostroy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace evrostroy.Web.Models
{
    public class MainCharacteristicProductModels
    {
        public IEnumerable<Товары> Products { get; set; }
        public string NameCategory { get; set; }
        public string Route { get; set; }
        public int Num { get; set; }
        public PagingInfo PagingInfo { get; set; }

       public List<SelectListItem> PageList { get; set; }
        
    }
       
}