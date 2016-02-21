using evrostroy.Domain;
using evrostroy.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace evrostroy.Web.Controllers
{
    public class AccountController : Controller
    {
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
            LogImplemetation.ClassLog.Write("Попытка входа "+ model.NameIn);
            ViewBag.Rest = false;
            try { 
                if (ModelState.IsValid)
                {//вызов метода удаления Log файлов каждый месяц 21 число
                    DeleteLog();
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
            catch(Exception er)
            {
                LogImplemetation.ClassLog.Write("Ошибка при входе AccountController\\Login: "+ er);
                return RedirectToAction("Exception");
            }
            
        }
        //метод очистки папки LOG каждый месяц
        private void DeleteLog()
        {
            if (DateTime.Now.Day == 21)
            {
                string domainpath = Server.MapPath("~//Log//");
                var dir = new DirectoryInfo(domainpath);
                FileInfo[] fileNames = dir.GetFiles("*.*");
                foreach (var item in fileNames)
                {
                    item.Delete();
                }
            }
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
            LogImplemetation.ClassLog.Write("Попытка регистрации нового пользователя " + model.NameUs + " "+model.EmailUs);
            ViewBag.Rest =false;
            Пользователи g = dataManager.UsersRepository.GetUsers().Where(x => x.Email == model.EmailUs).FirstOrDefault();
            //проверка на наличие такого пользователя в базе данных(если нет то регистрируем иначе оповеаем что есть и предлогаем восстановить пароль(нов пароль отправим по email))
            if (g==null)
            {
                if (ModelState.IsValid)
                     {
                        DateTime nowtime = DateTime.Now;
                        try
                        {
                            dataManager.UsersRepository.CreateUser(1, model.NameUs, model.PhoneUs, model.EmailUs, model.CityUs, model.StreetUs, model.PasswordUs, idroledefault, nowtime);
                            FormsAuthentication.SetAuthCookie(model.EmailUs, true);
                            Session["ИмяТекущегоПользователя"] = model.NameUs;//для отображения на экране
                        //метод отправки сообщения на email о регистрации
                            SendMessage.SendMsg.Message("Поздравляем Вас " + model.NameUs + ", Вы зарегистрировались в интернет магазине ЛюксЕвроСтрой", "Регитрация в интернет магазине ЛюксЕвроСтрой", model.EmailUs);
                            return RedirectToAction("ThanksForRegister", "Account", new { returnUrl });
                        }
                        catch (Exception er)
                        {
                            LogImplemetation.ClassLog.Write("Ошибка при регистрации AccountController\\Register:" + er);
                            return RedirectToAction("Exception");
                        }
                 }
            }
            else
            {
                ViewBag.Rest = true;
                ModelState.AddModelError("EmailUs", "Пользователь с таким email адресом уже существует.");
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
        public ActionResult RestorePassword(NewpasswordModel model)
        {
            try
            {
                LogImplemetation.ClassLog.Write("Восстановление пароля " + model.EmailUs);

                Пользователи g = dataManager.UsersRepository.GetUserByEmail(model.EmailUs);
                //проверка на наличие такого пользователя в базе данных(если нет то регистрируем иначе оповеаем что есть и предлогаем восстановить пароль(нов пароль отправим по email))
                if (g != null)
                {
                    //генератор паролей

                    if (ModelState.IsValid)
                    {
                        string password = GetPassword();

                        dataManager.UsersRepository.CreateUser(g.ИдПользователя, g.Имя,g.Телефон,g.Email,g.Город,g.УлицаДомКв,password,(int)g.ИдРоли,g.ДатаРегистрации);

                        SendMessage.SendMsg.Message("Новый пароль для входа на сайт: " + password, "Восстановление пароля", model.EmailUs);
                        return RedirectToAction("NewPasswordSend");
                    }
                }
                else
                {
                    ModelState.AddModelError("EmailUs", "Пользователя с таким email адресом не существует.");
                }

                return View(model);
            }
             catch(Exception er)
            {
                LogImplemetation.ClassLog.Write("Ошибка при восстановлении пароля AccountController\\RestorePassword: " + er);
                return RedirectToAction("Exception");
            }
        }
        //метод генерации пароля
        private static string GetPassword(int i=10)
        {
            string password = "";
            var r = new Random(); ;
            while(password.Length<=i)
            {
                Char c = (Char)r.Next(33, 125);
                if(Char.IsLetterOrDigit(c))
                {
                    password += c;
                }
            }
            return password;
        }



        //спасибо за регистрацию
        [HttpGet]
        public ActionResult ThanksForRegister(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult ThanksForRegister(string returnUrl, int id=0)
        {
            return RedirectToLocal(returnUrl);
        }

        //ошибка
        public ActionResult Exception()
        {
            return View();
        }
        //ошибка
        public ActionResult NewPasswordSend()
        {
            return View();
        }

    }
}