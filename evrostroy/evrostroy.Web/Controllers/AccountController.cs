using evrostroy.Domain;
using evrostroy.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace evrostroy.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string g = "i";
                Пользователи us = null;
                using (evrostroydbEntities context = new evrostroydbEntities())
                {
                    us = context.Пользователи.FirstOrDefault(u => u.Email == model.NameIn && u.Пароль == model.PasswordIn);
                }
                if (us != null)
                {
                    FormsAuthentication.SetAuthCookie(us.Имя, true);
                    //if(returnUrl)
                    return RedirectToLocal(returnUrl);

                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет или не правильно введен логин и пароль");
                }
            }
            return View(model);
        }

        //метод выхода
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("MainPage", "Home");
        }


        //Метод возврата на страницу с которой перешли на авторизацию
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("MainPage", "Home");
        }

    }
}