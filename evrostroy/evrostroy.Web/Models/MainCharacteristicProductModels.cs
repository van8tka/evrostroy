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
        public string Category { get; set; }
        public string Podcategory1 { get; set; }
        public string Podcategory2 { get; set; }
        public int ID { get; set; }
        public Товары Tov { get; set; }
        public ОснХарактеристики OsnTov { get; set; }
        public ДопХарактеристики DopTov { get; set; }
        public ФотоТовара PhotoTov { get; set; }

    }
       
}