using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BerkTokgozBlogSitesi.Models
{
    public class MakaleDetay
    {
        public int ID { get; set; }
        public string Baslik { get; set; }
        public string İcerik { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string KategoriAdi { get; set; }
        public int YorumSayisi { get; set; }
        public ICollection<Yorum> Yorumlar { get; set; }
        public string YorumIcerik { get; set; }
    }
}