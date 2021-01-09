using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BerkTokgozBlogSitesi.Models.ViewModel
{
    public class UyeDuzenle
    {
        public int ID { get; set; }

        [Required]
        public string Adi { get; set; }
    }
}