using evrostroy.Domain;
using evrostroy.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace evrostroy.Web.Controllers
{
    public class NavController : Controller
    {
       private DataManager datamanager;
        public NavController(DataManager datamanager)
        {
            this.datamanager = datamanager;
        }
        public PartialViewResult Menu()
        {
            NavModel model = new NavModel();
            try
            {
                List<string> AllItems = new List<string>();
                List<string> Another = new List<string>();
                List<string> Podcat = new List<string>();
                List<string> Podcat2 = new List<string>();
                List<string> Brand = new List<string>();
                List<string> Country = new List<string>();
                string br = "Брэнд";
                string countr = "Страна изготовитель";
                Another.Add(br);
                Another.Add(countr);
                model.Categories = datamanager.ProductsRepository.GetAllProducts().Select(x => x.Категория).Distinct().OrderBy(x => x);
               
                foreach (string c in model.Categories)
                    {
                    AllItems.Add(c);

                    IEnumerable<string> cf = datamanager.ProductsRepository.GetAllProducts().Where(z=>z.Категория == c).Select(x => x.Подкатегория1).Distinct().OrderBy(x => x);

                    if (cf.First()!= null)
                    {                   
                        foreach(string i in cf)
                        {
                            Podcat.Add(i);
                            AllItems.Add(i);
                          
                            IEnumerable<string> cs = datamanager.ProductsRepository.GetAllProducts().Where(z => z.Подкатегория1 == i).Select(x => x.Подкатегория2).Distinct().OrderBy(x => x);
                            if(cs.First() != null)
                            {
                                foreach (string item in cs)
                                {
                                    Podcat2.Add(item);
                                  AllItems.Add(item);
                                }
                               
                            }
                        }
                    }
                    else
                    {
                      

                        AllItems.Add(br);
                      
                        IEnumerable<string> bran = datamanager.ProductsRepository.GetAllProducts().Where(x=>x.Категория == c).Select(x => x.Производитель).Distinct().OrderBy(x=>x);
                        foreach(string i in bran)
                        {  AllItems.Add(i); Brand.Add(i); }

                        AllItems.Add(countr);
                        IEnumerable<string> co = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == c).Select(x => x.СтранаПроизводитель).Distinct().OrderBy(x => x);
                        foreach (var a in co)
                        {
                             AllItems.Add(a); Country.Add(a);
                        }
                        //if (c!="Входные двери")
                        //{
                        //    model.Material = datamanager.ProductsRepository.GetAllProducts().Select(x => x.).Distinct().OrderBy(x => x);
                        //}
                    }
                 
                }
                model.AllItems = AllItems;
                model.AnotherItems = Another;
                model.PodCategoriesF = Podcat;
                model.PodCategoriesS = Podcat2;
                model.Brand = Brand;
                model.Contry = Country;
                return PartialView(model);
            }
            catch(Exception er)
            {
                LogImplemetation.ClassLog.Write("Ошибка при создании бокового меню NavController/Menu: " + er);
                return PartialView();
            }
            return PartialView();
        }
    
    }
}