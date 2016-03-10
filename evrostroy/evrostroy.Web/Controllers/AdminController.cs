using evrostroy.Domain;
using evrostroy.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace evrostroy.Web.Controllers
{
    
    public class AdminController : Controller
    {
        private DataManager datamanager;
        public AdminController(DataManager datamanager)
        {
            this.datamanager = datamanager;
        }
            public ActionResult Mainpanel()
        {
            return View();
        }
        //РАБОТА С ТОВАРОМ (ВЫВОД ВСЕГО СПИСКА)
        [HttpGet]
        public ActionResult Tovar()
        {
            IEnumerable<Товары> tov = datamanager.ProductsRepository.GetAllProducts();
            ViewBag.Kolvo = tov.Count();
            return View(tov);
        }
        //добавление нового товара
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateTovarModel newtovar)
        {
            newtovar.ID = 0;
            if(ModelState.IsValid)
            {
                Товары tov = new Товары
                {
                    ИдТовара = newtovar.ID,
                    Название = newtovar.Nazvanie,
                    Производитель = newtovar.Proizvoditel,
                    СтранаПроизводитель = newtovar.StranaProizv,
                    Категория = newtovar.Kategoriya,
                    Подкатегория1 = newtovar.Podcategoriya1,
                    Подкатегория2 = newtovar.Podcategoriya2,
                    Метка = "новинка",
                    Публикация = newtovar.Publicaciya,
                    Цена = newtovar.Cena,
                   Скидка = null,
                   ЦенаСоСкидкой = null
                };
           
        }
            return View();
        }


    }
}