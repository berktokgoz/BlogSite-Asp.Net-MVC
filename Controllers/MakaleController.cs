using BerkTokgozBlogSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkTokgozBlogSitesi.Controllers
{
    public class MakaleController : Controller
    {
        // GET: Makale
        BerkTokgozBlogSitesi.Models.BerkTokgoz_BlogEntities db  = new Models.BerkTokgoz_BlogEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TariheGoreListe(int yil, int ay)
        {
            ViewBag.yil = yil;
            ViewBag.ay = ay;
            return View();
        }
        public ActionResult MakaleListele(int yil=0, int ay=0)
        {
            var data = db.Makale.Where(x => x.Tarih.Value.Year == yil && x.Tarih.Value.Month == ay);
            return View("MakaleListele", data);
        }
        public ActionResult Detay(int id)
        {

            ViewBag.Kullanici = Session["Kullanici"];

            Models.Makale mk = db.Makale.FirstOrDefault(x => x.ID == id);

            if (mk != null)
            {
                MakaleDetay model = new MakaleDetay
                {
                    ID = mk.ID,
                    Baslik = mk.Baslik,
                    KategoriAdi = mk.Kategori.Adi,
                    Tarih = mk.Tarih,
                    Yorumlar = mk.Yorum,
                    YorumSayisi = mk.Yorum.Count,
                    İcerik = mk.İcerik
                };

                return View(model);
            }

            return View(new MakaleDetay());
        }
            [HttpPost]
        public ActionResult Detay(BerkTokgozBlogSitesi.Models.MakaleDetay model)
        {
            var user = Session["UserInfo"] as BerkTokgozBlogSitesi.Models.ViewModel.UserInfo;

            if (ModelState.IsValid)
            {
                if (user.IsAdmin || user.Yazar || user.Uye)
                {
                    db.Yorum.Add(new Models.Yorum
                    {
                        İcerik = model.YorumIcerik,
                        MakaleID = model.ID,
                        YazarID = user.Id
                    });
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Detay", new { id = model.ID });

        }
       
    
    }
}