//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace evrostroy.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class ОснХарактеристики
    {
        public int ИдТовара { get; set; }
        public string Материал { get; set; }
        public string Покрытие { get; set; }
        public string Каркас { get; set; }
        public string Цвет { get; set; }
        public string ТипДвери { get; set; }
        public string ВнутреннееЗаполнение { get; set; }
        public string Наполнитель { get; set; }
        public string Уплотнитель { get; set; }
        public Nullable<int> ТолщинаМеталла { get; set; }
        public string Фурнитура { get; set; }
        public string Петли { get; set; }
        public string ОтделкаСнаружи { get; set; }
        public string ОтделкаВнутри { get; set; }
        public Nullable<int> ТолщДверногоПлотна { get; set; }
        public string ТипоразмерЦилиндра { get; set; }
        public string ТипКрепежа { get; set; }
        public Nullable<int> РекомендуемаяТолщинаДверногоПолотна { get; set; }
        public string ТипПланки { get; set; }
        public string Межосевое { get; set; }
        public string ДопЗапираниеИзнутри { get; set; }
        public string Коллекция { get; set; }
        public string КлассПрименения { get; set; }
        public string Основа { get; set; }
        public Nullable<int> ТолщЗащитногоСлоя { get; set; }
        public Nullable<int> ТолщПокрытияОбщая { get; set; }
        public Nullable<int> ШиринаРулона { get; set; }
        public string КлассИстираемости { get; set; }
        public Nullable<int> РазмерПанели { get; set; }
        public Nullable<int> КолвоВупаковке { get; set; }
        public Nullable<int> ПлощадьПачки { get; set; }
        public string Поверхность { get; set; }
        public string Гарантия { get; set; }
        public string ТипПокрытия { get; set; }
        public string ТипЗамковогоСоединения { get; set; }
        public string НаличиеФаски { get; set; }
        public string ПородаДерева { get; set; }
        public Nullable<int> Толщина { get; set; }
        public string Описание { get; set; }
    
        public virtual Товары Товары { get; set; }
    }
}
