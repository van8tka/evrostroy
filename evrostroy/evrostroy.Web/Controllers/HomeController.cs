using evrostroy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace evrostroy.Web.Controllers
{
    public class HomeController : Controller
    {
      private DataManager dataManager;
       
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public ActionResult MainPage()
        {
            IEnumerable<Пользователи> us = dataManager.UsersRepository.GetUsers();
            return View(us);
        }

      
    }
}