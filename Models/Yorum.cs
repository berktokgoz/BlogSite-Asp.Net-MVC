//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BerkTokgozBlogSitesi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Yorum
    {
        public int ID { get; set; }
        public string Baslik { get; set; }
        public string İcerik { get; set; }
        public Nullable<int> MakaleID { get; set; }
        public Nullable<System.DateTime> EklenmeTarihi { get; set; }
        public Nullable<int> YazarID { get; set; }
    
        public virtual Kullanici Kullanici { get; set; }
        public virtual Makale Makale { get; set; }
    }
}
