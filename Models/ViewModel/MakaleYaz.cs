using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BerkTokgozBlogSitesi.Models.ViewModel
{
    public class MakaleYaz
    {
        [Required]
        public string Baslik { get; set; }
        [Required]
        public string Icerik { get; set; }
        
        public int KatID { get; set; }
        
        public string Etkt { get; set; }
    }
}