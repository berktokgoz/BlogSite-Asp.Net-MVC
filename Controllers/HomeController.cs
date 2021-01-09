using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BerkTokgozBlogSitesi.Controllers
{
    public class HomeController : Controller
    {

        BerkTokgozBlogSitesi.Models.BerkTokgoz_BlogEntities db  = new Models.BerkTokgoz_BlogEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KategoriWidgetGetir()
        {
            return View(db.Kategori.ToList());
        }

        public ActionResult PostsWidgetGetir()
        {
            ViewBag.SonEklenenler = db.Makale.OrderByDescending(x => x.Tarih).Take(5).ToList();
            ViewBag.Populer = db.Makale.OrderByDescending(x => x.Goruntulenme).Take(5).ToList();

            return View();
        }
        public ActionResult TagsWidgetGetir()
        {
            var tags = db.Etiket.ToList();
            return View(tags);
        }
        public ActionResult TumMakaleleriGetir()
        {
            var makaleler = db.Makale.ToList();
            return View("MakaleListele", makaleler);
        }
        public ActionResult Anasayfa(int id = 0)
        {
            if (id == 0)
            {
                return View(db.Makale.ToList());
            }
            else
            {
                return View(db.Makale.Where(p=> p.ID == id).ToList());
            }
            
        }

    }
}