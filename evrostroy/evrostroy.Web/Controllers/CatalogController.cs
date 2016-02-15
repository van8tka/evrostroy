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

        public ActionResult ProductCategory(int num, string namecategory)
        {
            //параметры определены в navcontroller
            //int category = 0, podcat1 = 1, podcat2 = 2, ibrand = 3, icountry = 4, icolor = 5, imater = 6, idontactiv = 7;
            MainCharacteristicProductModels model = new MainCharacteristicProductModels();
            switch(num)
            {
                case 0:
                    model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x=>x.Категория == namecategory);
                    break;
                case 1:
                    model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Подкатегория1 == namecategory);
                    break;
                case 2:
                    model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Подкатегория2 == namecategory);
                    break;
                case 3:
                    model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Производитель == namecategory);
                    break;
                case 4:
                    model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.СтранаПроизводитель == namecategory);
                    break;
                case 5:
                    model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == namecategory);
                    break;
                case 6:
                    model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == namecategory);
                    break;
              
                default:
                    break;
            }
            model.NameCategory = namecategory;
            return View(model);
        }

    }
}