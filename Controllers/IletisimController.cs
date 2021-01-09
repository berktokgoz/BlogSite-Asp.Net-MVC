using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkTokgozBlogSitesi.Controllers
{
    public class IletisimController : Controller
    {
        BerkTokgozBlogSitesi.Models.BerkTokgoz_BlogEntities db  = new Models.BerkTokgoz_BlogEntities();
        // GET: Iletisim
        public ActionResult Iletisim()
        {
            var model = db.Iletisim.FirstOrDefault();
            model = model == null ? new Models.Iletisim { Baslik = "", Icerik = "" } : model;
            return View(model);
        }
    }
}