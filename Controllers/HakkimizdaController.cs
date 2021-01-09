using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkTokgozBlogSitesi.Controllers
{
    public class HakkimizdaController : Controller
    {
        BerkTokgozBlogSitesi.Models.BerkTokgoz_BlogEntities db  = new Models.BerkTokgoz_BlogEntities();
        // GET: Hakkimizda
        public ActionResult Hakkimizda()
        {
            var model = db.Hakkimizda.FirstOrDefault();
            model = model == null ? new Models.Hakkimizda { Baslik = "", Icerik = "" } : model;
            return View(model);
        }
    }
}