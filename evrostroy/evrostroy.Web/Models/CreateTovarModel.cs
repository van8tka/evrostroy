using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace evrostroy.Web.Models
{
    public class CreateTovarModel
    {
        //товар
        public int ID { get; set; }
        [Required]
        [Display(Name ="Название")]
        public string Nazvanie {get;set;}
        [Display(Name = "Производитель")]
        public string Proizvoditel {get;set;}
        [Display(Name = "Страна производитель")]
        public string StranaProizv {get;set;}
        [Display(Name = "Категория")]
        public string Kategoriya {get;set;}
        [Display(Name = "Подкатегория 1")]
        public string Podcategoriya1 {get;set;}
        [Display(Name = "Подкатегория 2")]
        public string Podcategoriya2 { get;set;}
        [Display(Name = "Метка")]
        public string Metka {get;set;}
        [Display(Name = "Публикация")]
        public bool Publicaciya { get; set; }
        [Display(Name = "Цена")]
        [Required(ErrorMessage ="Введите цену товара!")]
        [RegularExpression(@"^[0-9]{1,20}", ErrorMessage = "Неверный формат ввода цены товара!")]
        public int Cena { get; set; }
        [Display(Name = "Скидка")]
        [RegularExpression(@"^[0-9]{1,20}", ErrorMessage = "Неверный формат ввода скидки товара!")]
        public int Skidka { get; set; }
        //[Display(Name = "")]
        //public int CenaSoSkidkoy { get; set; }
        //осн характеристики
        [Display(Name = "Материал")]
        public string Material { get; set; }
        [Display(Name = "Покрытие")]
        public string Pokrytie { get; set; }
        [Display(Name = "Каркас")]
        public string Karkas { get; set; }
        [Display(Name = "Цвет")]
        public string Cvet { get; set; }
        [Display(Name = "Тип двери")]
        public string TypDveri { get; set; }
        [Display(Name = "Внутреннее заполнение")]
        public string VnutrZapoln { get; set; }
        [Display(Name = "Наполнитель")]
        public string Napolnitel { get; set; }
        [Display(Name = "Уплотнитель")]
        public string Yplotnitel { get; set; }
        [Display(Name = "Толщина металла")]
        [RegularExpression(@"^[0-9]{1,20}", ErrorMessage = "Неверный формат ввода толщины металла(допускает только цифры)!")]
        public int TolschinaMetala  { get; set; }
        [Display(Name = "Фурнитура")]
        public string Furnitura { get; set; }
        [Display(Name = "Петли")]
        public string Petli { get; set; }
        [Display(Name = "Отделка снаружи")]
        public string OtdelkaSnarugi { get; set; }
        [Display(Name = "Отделка внутри")]
        public string OtdelkaVnutri { get; set; }
        [Display(Name = "Толщина дверного полотна")]
        [RegularExpression(@"^[0-9]{1,20}", ErrorMessage = "Неверный формат ввода толщины дверного полотна(допускает только цифры)!")]
        public int TolschDverPolotn { get; set; }
        [Display(Name = "Типоразмер цилиндра")]
        public string TyporazmCilindra { get; set; }
        [Display(Name = "Тип крепежа")]
        public string TypKrepega { get; set; }
        [Display(Name = "Рекомендуемая толщина дверного проема")]
        public string RekomendTolschinaDvPolotna { get; set; }
        [Display(Name = "Тип планки")]
        public string TypPlanki { get; set; }
        [Display(Name = "Межосевое")]
        public string Megosevoe { get; set; }
        [Display(Name = "Дополнительное запирание изнутри")]
        public string DopZapiranieIznutri{ get; set; }
        [Display(Name = "Коллекция")]
        public string Kollekciya { get; set; }
        [Display(Name = "Класс применения")]
        public string KlassPrimeneniya{ get; set; }
        [Display(Name = "Основа")]
        public string Osnova{ get; set; }
        [Display(Name = "Толщина защитного слоя")]
        [RegularExpression(@"^[0-9]{1,20}", ErrorMessage = "Неверный формат ввода толщины защитного слоя(допускает только цифры)!")]
        public int TolschZaschSloya { get; set; }
        [Display(Name = "Толщина покрытия общая")]
        [RegularExpression(@"^[0-9]{1,20}", ErrorMessage = "Неверный формат ввода толщины покрытия(допускает только цифры)!")]
        public int TolschPokrObsch { get; set; }
        [Display(Name = "Ширина рулона")]
        [RegularExpression(@"^[0-9]{1,20}", ErrorMessage = "Неверный формат ввода ширины рулона(допускает только цифры)!")]
        public int ShirinaRulona{ get; set; }
        [Display(Name = "Класс истираемости")]
        public string KlassIstiraem{ get; set; }
        [Display(Name = "Размер панели")]
        [RegularExpression(@"^[0-9]{1,20}", ErrorMessage = "Неверный формат ввода размера панели(допускает только цифры)!")]
        public int RazmerPaneli { get; set; }
        [Display(Name = "Кол-во в упаковке")]
        [RegularExpression(@"^[0-9]{1,20}", ErrorMessage = "Неверный формат ввода кол-ва в упаковке(допускает только цифры)!")]
        public int KolvoVupakovke { get; set; }
        [Display(Name = "Площадь пачки")]
        [RegularExpression(@"^[0-9]{1,20}", ErrorMessage = "Неверный формат ввода площади пачки(допускает только цифры)!")]
        public int PloschPachki { get; set; }
        [Display(Name = "Поверхность")]
        public string Poverhnost { get; set; }
        [Display(Name = "Гарантия")]
        public string Garantiya { get; set; }
        [Display(Name = "Тип покрытия")]
        public string TypPokrytiya{ get; set; }
        [Display(Name = "Тип замкового соединения")]
        public string TypZamkSoedin{ get; set; }
        [Display(Name = "Наличие фаски")]
        public string NalichieFaski{ get; set; }
        [Display(Name = "Порода дерева")]
        public string PorodaDereva{ get; set; }
        [Display(Name = "Толщина")]
        [RegularExpression(@"^[0-9]{1,20}", ErrorMessage = "Неверный формат ввода толщины(допускает только цифры)!")]
        public int Tolschina { get; set; }
        [Display(Name = "Описание")]
        public string Opisanie{ get; set; }
    }
}