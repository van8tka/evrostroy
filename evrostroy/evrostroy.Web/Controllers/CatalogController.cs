using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace evrostroy.Web.Controllers
{
    public class CatalogController : Controller
    {

      [Authorize(Roles = "администратор,покупатель")]
        public ActionResult Price()
        {
            return View();
        }
    }
}