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

        private string novinka = "новинка";
        private string ycenka = "уценка";
        private string skidka = "скидка";

        public ActionResult Price()
        {
            return View();
        }

        //про акционные товары скидка уценка новинка
        [HttpGet]
        public ActionResult ProductStock(int page = 1, string metka = null, int PageSize = 50)
        {
            MainCharacteristicProductModels model = new MainCharacteristicProductModels();
       
            model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Метка == metka.ToLower()).OrderBy(x => x.ИдТовара).Skip((page - 1) * PageSize).Take(PageSize);
            int TotalItemsProduct = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Метка == metka.ToLower()).Count();

            List<SelectListItem> CountItemPerPage = new List<SelectListItem>();

            CountItemPerPage.Add(new SelectListItem { Text = "50", Value = "50" });
            CountItemPerPage.Add(new SelectListItem { Text = "100", Value = "100" });
            CountItemPerPage.Add(new SelectListItem { Text = "150", Value = "150" });
            CountItemPerPage.Add(new SelectListItem { Text = "200", Value = "200" });

            model.PageList = CountItemPerPage;
            model.PagingInfo = new PagingInfo()
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = TotalItemsProduct
            };
            model.Category = metka;
            model.NameCategory = metka;
            model.Route = metka;
            return View(model);
        }

        [HttpPost]
        public ActionResult ProductStock(MainCharacteristicProductModels model)
        {
            return RedirectToAction("ProductStock", new { metka = model.NameCategory, PageSize = model.PagingInfo.ItemsPerPage });
        }


        //обработка нового меню для дверей 
        [HttpGet]
        public ActionResult ProductCat(int page = 1, int num = -1, string name = null, string cat = null, string podcat = null, int PageSize = 50)
        {
            MainCharacteristicProductModels model = new MainCharacteristicProductModels();
            int TotalItemsProduct = 0;
            string podcat2 = null;
            if (cat!=null && num==-1)
            {
                IEnumerable<Товары> categor = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == cat).OrderBy(x => x.Название);
              
                    if (podcat != null)
                    {
                    
                        IEnumerable<Товары> podcattov = categor.Where(x => x.Подкатегория1 == podcat).OrderBy(x => x.Название);
                        if(podcat==name) //выбор подкатегории в хлебных крошках
                    {
                            model.Products = podcattov.Skip((page - 1) * PageSize).Take(PageSize);
                            TotalItemsProduct = podcattov.Count();
                            name = podcat;
                            model.NameCategory = name;
                            model.Route = cat + "/" + podcat;
                        }
                        else
                        {
                            if ((podcattov.First() != null || podcattov.Last() != null) || name != null)
                            {
                                model.Products = podcattov.Where(x => x.Подкатегория2 == name).OrderBy(x => x.Название).Skip((page - 1) * PageSize).Take(PageSize);
                                TotalItemsProduct = podcattov.Where(x => x.Подкатегория2 == name).OrderBy(x => x.Название).Count();
                                model.NameCategory = name;
                                model.Route = cat + "/" + podcat + "/" + name;
                                podcat2 = name;
                            }
                        }
                         
                    }
               }
            switch (num)
            {
                case 0://входные двери производитель
                    {
                        model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == "Входные двери").Where(x => x.Производитель == name).OrderBy(x => x.Название).Skip((page - 1) * PageSize).Take(PageSize);
                        TotalItemsProduct = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == "Входные двери").Where(x => x.Производитель == name).Count();
                        model.NameCategory = name;
                        model.Route = "Входные двери/Производитель/" + name;
                        cat = "Входные двери";
                        podcat = "Производитель";
                        podcat2 = name;
                        break;
                    }
               case 2://межкомнатные двери производитель
                    {
                        model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == "Межкомнатные двери").Where(x => x.Производитель == name).OrderBy(x => x.Название).Skip((page - 1) * PageSize).Take(PageSize);
                        TotalItemsProduct = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == "Межкомнатные двери").Where(x => x.Производитель == name).Count();
                        model.NameCategory = name;
                        cat = "Межкомнатные двери";
                        podcat = "Производитель";
                        podcat2 = name;
                        model.Route = "Межкомнатные двери/Производитель/" + name;
                        break;
                    }
                case 1://выбор категории
                    {
                        IEnumerable<Товары> categor = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == name).OrderBy(x => x.Название);
                        model.Products = categor.Skip((page - 1) * PageSize).Take(PageSize);
                            TotalItemsProduct = categor.Count();
                            model.NameCategory = name;
                            model.Route = name;
                            cat = name;
                        break;
                     }
               default:
                    break;
            }

            List<SelectListItem> CountItemPerPage = new List<SelectListItem>();
         
            CountItemPerPage.Add(new SelectListItem { Text = "50", Value = "50" });
            CountItemPerPage.Add(new SelectListItem { Text = "100", Value = "100" });
            CountItemPerPage.Add(new SelectListItem { Text = "150", Value = "150" });
            CountItemPerPage.Add(new SelectListItem { Text = "200", Value = "200" });

            model.PageList = CountItemPerPage;

            model.PagingInfo = new PagingInfo()
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = TotalItemsProduct
            };
            model.Podcategory2 = podcat2;
            model.Podcategory1 = podcat;
            model.Category = cat;
            model.Num = num;
            return View(model);
        }

        [HttpPost]
        public ActionResult ProductCat(MainCharacteristicProductModels model)
        {
            return RedirectToAction("ProductCat", new { num = model.Num, name = model.NameCategory,route = model.Route, PageSize = model.PagingInfo.ItemsPerPage });
        }
       
        // хлебные крошки
        public PartialViewResult BreadCrumbs(MainCharacteristicProductModels mod, string additem=null)
        {       
            return PartialView(mod);
        }

        //Информация о выбранном товаре
        [HttpGet]
        public ActionResult TovarInfo(int id=0,int num=-1, string cat = null, string podcat1 = null, string podcat2 = null )
        {//создаем модель для передачи в хлебные крошки
            MainCharacteristicProductModels mod = new MainCharacteristicProductModels();
            mod.Num = num;
            mod.Category = cat;
            mod.Tov = datamanager.ProductsRepository.GetProductByID(id);
         
            if ((cat != novinka.ToUpper() && cat != ycenka.ToUpper()&&cat != skidka.ToUpper())&&(podcat1 == null || podcat1 == ""))
               {
                    mod.Podcategory1 = mod.Tov.Подкатегория1;
                    if (podcat2 == null || podcat2 == "")
                    {
                        mod.Podcategory2 = mod.Tov.Подкатегория2;
                    }
                    else
                    {
                        mod.Podcategory2 = podcat2;
                    }
            }
            else
            {
                mod.Podcategory1 = podcat1;
                if (podcat2 == null || podcat2 == "")
                {
                    mod.Podcategory2 = mod.Tov.Подкатегория2;
                }
                else
                {
                    mod.Podcategory2 = podcat2;
                }
            }
           
          
          
            mod.ID = id;
           
            return View(mod);
        }

    }
}