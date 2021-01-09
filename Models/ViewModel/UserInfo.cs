using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BerkTokgozBlogSitesi.Models.ViewModel
{
    public class UserInfo
    {
        
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public bool Yazar { get; set; }
        public bool Uye { get; set; }
        public int Id { get; set; }
    }
}