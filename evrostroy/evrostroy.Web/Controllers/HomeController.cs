using evrostroy.Domain;
using evrostroy.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            ForMainBannerModel model = new ForMainBannerModel();
            string domainpath = Server.MapPath("~/Content/ImageForMainBanner");
            //получаем путь 
            var dir = new DirectoryInfo(domainpath);
            //получаем список файлов
            FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> item = new List<string>();
            //добавляем их в список
            foreach (var file in fileNames)
            {
                item.Add(file.Name);
            }
            model.FileName = item;
            model.CountFile = item.Count();

            return View(model);
        }

      
    }
}