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
    
    public partial class ДопХарактеристики
    {
        public int ИдДопХарактеристики { get; set; }
        public int ИдТовара { get; set; }
        public string Название { get; set; }
        public string Значение { get; set; }
    
        public virtual Товары Товары { get; set; }
    }
}
