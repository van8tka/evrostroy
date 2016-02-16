using evrostroy.Domain;
using evrostroy.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace evrostroy.Web.Controllers
{
    public class CatalogController : Controller
    {
      private DataManager datamanager;
        public CatalogController(DataManager datamanager)
        {
            this.datamanager = datamanager;
        }

     
        public ActionResult Price()
        {
            return View();
        }

        public ActionResult ProductStock(string metka)
        {
            MainCharacteristicProductModels model = new MainCharacteristicProductModels();
            model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Метка == metka.ToLower());
           
           model.NameCategory = metka;       
            return View(model);
        }

        public ActionResult ProductCategory(int num, string namecategory, string route)
        {
            //параметры определены в navcontroller
            //int category = 0, podcat1 = 1, podcat2 = 2, ibrand = 3, icountry = 4, icolor = 5, imater = 6, idontactiv = 7;
            MainCharacteristicProductModels model = new MainCharacteristicProductModels();
            switch (num)
            {
                case 0://каталог
                    {
                        model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == namecategory);
                        break;
                    }
                case 1://подкаталог1
                    model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Подкатегория1 == namecategory);
                    break;
                case 2://полкаталог2
                    model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Подкатегория2 == namecategory);
                    break;
                case 3://брэнд(производитель)
                    {
                        string[] pars = new string[] { };
                        if (route != null)
                            pars = route.Split('/');
                        IEnumerable<Товары> temp = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == pars[0]);
                        model.Products = temp.Where(x => x.Производитель == namecategory);
                        break;
                    }
                case 4://страна производитель
                    { 
                    string[] pars = new string[] { };
                    if (route != null)
                        pars = route.Split('/');
                        IEnumerable<Товары> temp = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == pars[0]);
                        model.Products = temp.Where(x => x.СтранаПроизводитель == namecategory);
                    break;
                    }
                case 5://цвет
                    {
                        string[] pars = new string[] { };
                        if (route != null)
                            pars = route.Split('/');
                        model.Products = datamanager.ProductsRepository.GetMainCharByCateg(pars[0]).Where(x=>x.Цвет == namecategory).Select(z=>z.Товары);
                        break;
                    }
                case 6:
                    {//материал
                        string[] pars = new string[] { };
                        if (route != null)
                            pars = route.Split('/');
                        model.Products = datamanager.ProductsRepository.GetMainCharByCateg(pars[0]).Where(x => x.Материал == namecategory).Select(z => z.Товары).OrderBy(x => x);
                        break;
                    }
                default:
                    break;
            }
            model.Route = route;
            model.NameCategory = namecategory;
            return View(model);
        }

        // хлебные крошки
        public PartialViewResult BreadCrumbs(string route = null, string additem=null)
        {
            string[] pars = new string[] { };
            if (route!=null)
                pars = route.Split('/');
          
            return PartialView(pars);
        }

    }
}