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

        //про акционные товары скидка уценка новинка
        [HttpGet]
        public ActionResult ProductStock(int page = 1, string metka = null, int PageSize = 10)
        {
            MainCharacteristicProductModels model = new MainCharacteristicProductModels();
            model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Метка == metka.ToLower()).OrderBy(x => x.ИдТовара).Skip((page - 1) * PageSize).Take(PageSize);
            int TotalItemsProduct = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Метка == metka.ToLower()).Count();

            List<SelectListItem> CountItemPerPage = new List<SelectListItem>();

            CountItemPerPage.Add(new SelectListItem { Text = "10", Value = "10" });
            CountItemPerPage.Add(new SelectListItem { Text = "20", Value = "20" });
            CountItemPerPage.Add(new SelectListItem { Text = "50", Value = "50" });
            CountItemPerPage.Add(new SelectListItem { Text = "100", Value = "100" });

            model.PageList = CountItemPerPage;
            model.PagingInfo = new PagingInfo()
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = TotalItemsProduct
            };
            model.NameCategory = metka;
            model.Route = metka;
            return View(model);
        }

        [HttpPost]
        public ActionResult ProductStock(MainCharacteristicProductModels model)
        {
            return RedirectToAction("ProductStock", new { metka = model.NameCategory, PageSize = model.PagingInfo.ItemsPerPage });
        }


        //все категории
        [HttpGet]
        public ActionResult ProductCategory(int page = 1, int num = -1, string namecategory = null, string route = null, int PageSize = 10)
        {
            int TotalItemsProduct = 0;
            //параметры определены в navcontroller
            //int category = 0, podcat1 = 1, podcat2 = 2, ibrand = 3, icountry = 4, icolor = 5, imater = 6, idontactiv = 7;
            MainCharacteristicProductModels model = new MainCharacteristicProductModels();
            switch (num)
            {
                case 0://каталог
                    {
                        model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == namecategory).OrderBy(x => x.ИдТовара).Skip((page - 1) * PageSize).Take(PageSize);
                        TotalItemsProduct = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == namecategory).Count();
                        break;
                    }
                case 1://подкаталог1
                    {
                        model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Подкатегория1 == namecategory).OrderBy(x => x.ИдТовара).Skip((page - 1) * PageSize).Take(PageSize);
                        TotalItemsProduct = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Подкатегория1 == namecategory).Count();
                        break;
                    }
                case 2://полкаталог2
                    {
                        model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Подкатегория2 == namecategory).OrderBy(x => x.ИдТовара).Skip((page - 1) * PageSize).Take(PageSize);
                        TotalItemsProduct = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Подкатегория2 == namecategory).Count();
                        break;
                    }
                case 3://брэнд(производитель)
                    {
                        string[] pars = new string[] { };
                        if (route != null)
                            pars = route.Split('/');
                        IEnumerable<Товары> temp = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == pars[0]);
                        model.Products = temp.Where(x => x.Производитель == namecategory).OrderBy(x => x.ИдТовара).Skip((page - 1) * PageSize).Take(PageSize);
                        TotalItemsProduct = temp.Where(x => x.Производитель == namecategory).Count();
                        break;
                    }
                case 4://страна производитель
                    {
                        string[] pars = new string[] { };
                        if (route != null)
                            pars = route.Split('/');
                        IEnumerable<Товары> temp = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == pars[0]);
                        model.Products = temp.Where(x => x.СтранаПроизводитель == namecategory).OrderBy(x => x.ИдТовара).Skip((page - 1) * PageSize).Take(PageSize);
                        TotalItemsProduct = temp.Where(x => x.СтранаПроизводитель == namecategory).Count();
                        break;
                    }
                case 5://цвет
                    {
                        string[] pars = new string[] { };
                        if (route != null)
                            pars = route.Split('/');
                        model.Products = datamanager.ProductsRepository.GetMainCharByCateg(pars[0]).Where(x => x.Цвет == namecategory).Select(z => z.Товары).OrderBy(x => x.ИдТовара).Skip((page - 1) * PageSize).Take(PageSize);
                        TotalItemsProduct = datamanager.ProductsRepository.GetMainCharByCateg(pars[0]).Where(x => x.Цвет == namecategory).Select(z => z.Товары).Count();
                        break;
                    }
                case 6:
                    {//материал
                        string[] pars = new string[] { };
                        if (route != null)
                            pars = route.Split('/');
                        model.Products = datamanager.ProductsRepository.GetMainCharByCateg(pars[0]).Where(x => x.Материал == namecategory).Select(z => z.Товары).OrderBy(x => x).OrderBy(x => x.ИдТовара).Skip((page - 1) * PageSize).Take(PageSize);
                        TotalItemsProduct = datamanager.ProductsRepository.GetMainCharByCateg(pars[0]).Where(x => x.Материал == namecategory).Select(z => z.Товары).Count();
                        break;
                    }
                default:
                    break;
            }
            List<SelectListItem> CountItemPerPage = new List<SelectListItem>();

            CountItemPerPage.Add(new SelectListItem { Text = "10", Value = "10" });
            CountItemPerPage.Add(new SelectListItem { Text = "20", Value = "20" });
            CountItemPerPage.Add(new SelectListItem { Text = "50", Value = "50" });
            CountItemPerPage.Add(new SelectListItem { Text = "100", Value = "100" });

            model.PageList = CountItemPerPage;
            model.PagingInfo = new PagingInfo()
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = TotalItemsProduct
            };
            model.Num = num;
            model.Route = route;
            model.NameCategory = namecategory;
            return View(model);
        }

        [HttpPost]
        public ActionResult ProductCategory(MainCharacteristicProductModels model)
        {
            return RedirectToAction("ProductCategory", new { num = model.Num, namecategory = model.NameCategory, route = model.Route, PageSize = model.PagingInfo.ItemsPerPage });
        }

        //обработка нового меню
        [HttpGet]
        public ActionResult ProductCat(int page = 1,int num = -1,string name = null, int PageSize = 10)
       {
            MainCharacteristicProductModels model = new MainCharacteristicProductModels();
            int TotalItemsProduct = 0;
            switch (num)
            {//входные двери
                case 0://производитель
                    {
                        model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == "Входные двери").Where(x=>x.Производитель==name).OrderBy(x=>x.Название).Skip((page-1)*PageSize).Take(PageSize);                      
                        TotalItemsProduct = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == "Входные двери").Where(x => x.Производитель == name).Count();
                        model.NameCategory = name;
                        model.Route = "Входные двери/Производитель/"+name;
                        break;
                    }
                case 1:
                    {
                        model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == "Входные двери").Where(x => x.СтранаПроизводитель == name).OrderBy(x => x.Название).Skip((page - 1) * PageSize).Take(PageSize);
                        TotalItemsProduct = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == "Входные двери").Where(x => x.СтранаПроизводитель == name).Count();
                        model.NameCategory = name;
                        model.Route = "Входные двери/Страна производитель/" + name;
                        break;
                    }
                case 2:
                    {
                        model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == "Межкомнатные двери").Where(x => x.Производитель == name).OrderBy(x => x.Название).Skip((page - 1) * PageSize).Take(PageSize);
                        TotalItemsProduct = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == "Межкомнатные двери").Where(x => x.Производитель == name).Count();
                        model.NameCategory = name;
                        model.Route = "Межкомнатные двери/Производитель/" + name;
                        break;
                    }
                case 3:
                    {
                        model.Products = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == "Межкомнатные двери").Where(x => x.СтранаПроизводитель == name).OrderBy(x => x.Название).Skip((page - 1) * PageSize).Take(PageSize);
                        TotalItemsProduct = datamanager.ProductsRepository.GetAllProducts().Where(x => x.Категория == "Межкомнатные двери").Where(x => x.СтранаПроизводитель == name).Count();
                        model.NameCategory = name;
                        model.Route = "Межкомнатные двери/Страна производитель/"+ name;
                        break;
                    }
                case 4:
                    {
                        model.Products = datamanager.ProductsRepository.GetMainCharByCateg("Межкомнатные двери").Where(x => x.Цвет == name).Select(z => z.Товары).OrderBy(x => x.Название).Skip((page - 1) * PageSize).Take(PageSize);
                        TotalItemsProduct = datamanager.ProductsRepository.GetMainCharByCateg("Межкомнатные двери").Where(x => x.Цвет == name).Count();
                        model.NameCategory = name;
                        model.Route = "Межкомнатные двери/Цвет/" + name;
                        break;
                    }
                case 5:
                    {
                        model.Products = datamanager.ProductsRepository.GetMainCharByCateg("Межкомнатные двери").Where(x => x.Материал == name).Select(z => z.Товары).OrderBy(x => x.Название).Skip((page - 1) * PageSize).Take(PageSize);
                        TotalItemsProduct = datamanager.ProductsRepository.GetMainCharByCateg("Межкомнатные двери").Where(x => x.Материал == name).Count();
                        model.NameCategory = name;
                        model.Route = "Межкомнатные двери/Материал/" + name;
                        break;
                    }
                default:
                    break;
            }
            List<SelectListItem> CountItemPerPage = new List<SelectListItem>();

            CountItemPerPage.Add(new SelectListItem { Text = "10", Value = "10" });
            CountItemPerPage.Add(new SelectListItem { Text = "20", Value = "20" });
            CountItemPerPage.Add(new SelectListItem { Text = "50", Value = "50" });
            CountItemPerPage.Add(new SelectListItem { Text = "100", Value = "100" });

            model.PageList = CountItemPerPage;


            model.PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = TotalItemsProduct
                    };
            model.Num = num;
                     return View(model);
     }

        [HttpPost]
        public ActionResult ProductCat(MainCharacteristicProductModels model)
        {
            return RedirectToAction("ProductCat", new { num = model.Num, name = model.NameCategory, route = model.Route, PageSize = model.PagingInfo.ItemsPerPage });
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