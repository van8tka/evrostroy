﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace evrostroy.Web.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage="Введите имя!")]
        [RegularExpression(@"^[а-яА-Я]{1,50}", ErrorMessage = "Неверный формат имени!")]
        [Display(Name = "Имя")]
        public string NameUs { get; set; }

        [Required(ErrorMessage ="Введите номер телефона!")]
        [RegularExpression(@"^[0-9-+)(]{1,20}", ErrorMessage = "Неверный формат ввода номера телефона!")]
        [Display(Name = "Телефон")]
        public string PhoneUs { get; set; }

        [Required(ErrorMessage = "Введите email адрес!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9.-]{1,30}@[a-zA-Z0-9]{1,20}\.[A-Za-z]{2,6}", ErrorMessage = "Неверный формат email(xxxxxx@xxx.xx).")]
        public string EmailUs { get; set; }


        [Required(ErrorMessage ="Введите название города!")]
        [Display(Name = "Город")]
        [RegularExpression(@"^[а-яА-Я-]{1,150}", ErrorMessage = "Неверный формат названия города!")]
        public string CityUs { get; set; }

        [Required(ErrorMessage = "Введите название улицы и номер дома, подъезда, этажа и квартиры!")]
        [Display(Name = "Улица, дом, подъезд, этаж, квартира")]
        public string StreetUs { get; set; }


        [Required(ErrorMessage ="Введите пароль!")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string PasswordUs { get; set; }


        [Required(ErrorMessage = "Введите пароль!")]
        [Display(Name = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Compare("PasswordUs", ErrorMessage = "Пароли не совпадают!")]
        public string ConfPassword { get; set; }

    }


    public class LoginModel
    {
        [Required(ErrorMessage = "Введите email адрес!")]
        [Display(Name = "Имя пользователя(Email)")]
        [RegularExpression(@"^[a-zA-Z0-9.-]{1,30}@[a-zA-Z0-9]{1,20}\.[A-Za-z]{2,6}", ErrorMessage = "Неверный формат email(xxxxx@xxx.xx).")]
        [DataType(DataType.EmailAddress)]
        public string NameIn { get; set; }
        [Required(ErrorMessage = "Введите пароль!")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string PasswordIn { get; set; }
    }

    public class NewpasswordModel
    {
        [Required(ErrorMessage = "Введите email адрес!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9.-]{1,30}@[a-zA-Z0-9]{1,20}\.[A-Za-z]{2,6}", ErrorMessage = "Неверный формат email(xxxxxx@xxx.xx).")]
        public string EmailUs { get; set; }
    }
}