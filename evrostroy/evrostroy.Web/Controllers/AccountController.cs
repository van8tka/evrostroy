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
        private string SystemEmail = "systememail11@mail.ru";
        private string Passwword = "qazWSX123";

        private DataManager dataManager;
        public AccountController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

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
            ViewBag.Rest = false;
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
                    FormsAuthentication.SetAuthCookie(us.Email, true);
                    Session["ИмяТекущегоПользователя"] = us.Имя;
                    if (returnUrl != "/")
                    {
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("MainPage", "Home");
                    }
                }
                else
                {
                    ViewBag.Rest = true;
                    ModelState.AddModelError("NameIn", "Пользователя с таким логином и паролем нет или не правильно введен логин и пароль");
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

        //регистрация
        [HttpGet]
        public ActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model, string returnUrl)
        {
            int idroledefault = 2;//покупатель                      
            if (ModelState.IsValid)
            {
                DateTime nowtime = DateTime.Now;
                try
                {
                  dataManager.UsersRepository.CreateUser(1, model.NameUs, model.PhoneUs, model.EmailUs, model.CityUs, model.StreetUs, model.PasswordUs,idroledefault,nowtime);
                    FormsAuthentication.SetAuthCookie(model.EmailUs, true);
                    Session["ИмяТекущегоПользователя"] = model.NameUs;
                    return RedirectToAction("ThanksForRegister");
                }
                catch
                {
                    return RedirectToAction("Exception");
                }
                    
            }
            return View(model);
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

        //восстановление пароля
        [HttpGet]
        public ActionResult RestorePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RestorePassword(string email)
        {
            return View();
        }

        //спасибо за регистрацию
        public ActionResult ThanksForRegister()
        {
            return View();
        }
        //ошибка
        public ActionResult Exception()
        {
            return View();
        }
    }
}