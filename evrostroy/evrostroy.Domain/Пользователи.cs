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
    
    public partial class Пользователи
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Пользователи()
        {
            this.Заказы = new HashSet<Заказы>();
            this.ОтзывМагазина = new HashSet<ОтзывМагазина>();
            this.ОтзывТовара = new HashSet<ОтзывТовара>();
        }
    
        public int ИдПользователя { get; set; }
        public string Имя { get; set; }
        public string Телефон { get; set; }
        public string Email { get; set; }
        public string Город { get; set; }
        public string УлицаДомКв { get; set; }
        public string Пароль { get; set; }
        public Nullable<int> ИдРоли { get; set; }
        public Nullable<System.DateTime> ДатаРегистрации { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Заказы> Заказы { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ОтзывМагазина> ОтзывМагазина { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ОтзывТовара> ОтзывТовара { get; set; }
        public virtual Роли Роли { get; set; }
    }
}
