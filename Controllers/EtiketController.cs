using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkTokgozBlogSitesi.Controllers
{
    public class EtiketController : Controller
    {
        // GET: Etiket
        BerkTokgozBlogSitesi.Models.BerkTokgoz_BlogEntities db  = new Models.BerkTokgoz_BlogEntities();
        public ActionResult Index(int ID)
        {
            return View(ID);
        }
        public ActionResult MakaleListele(int ID)
        {
            var data = db.Makale.Where(x => x.Etiket.Any(me => me.ID == ID));
            return View("MakaleListele", data);

        }
    }
}