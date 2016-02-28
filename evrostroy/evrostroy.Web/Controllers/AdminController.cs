using evrostroy.Domain;
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
    }
}