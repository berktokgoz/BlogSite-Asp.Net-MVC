using BerkTokgozBlogSitesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;




namespace BerkTokgozBlogSitesi.Controllers
{

    public class YoneticiController : Controller
    {
        // GET: Yonetici
        BerkTokgozBlogSitesi.Models.BerkTokgoz_BlogEntities db = new Models.BerkTokgoz_BlogEntities();

        public ActionResult MakaleYaz()
        {
            var list = db.Kategori.ToList();

            if (list != null)
            {
                list.Insert(0, new Models.Kategori { Adi = "Seçiniz", ID = 0 });
            }

            ViewBag.Kategoriler = list;
            return View();
        }

        [HttpPost]
        public ActionResult MakaleYaz(Models.ViewModel.MakaleYaz model)
        {
            var user = Session["UserInfo"] as BerkTokgozBlogSitesi.Models.ViewModel.UserInfo;
            
            if (ModelState.IsValid)
            {
                if (user.IsAdmin || user.Yazar)
                {
                    db.Makale.Add(new Models.Makale
                    {
                       Tarih=DateTime.Now,
                    Baslik = model.Baslik,
                        İcerik = model.Icerik,
                        KategoriID = model.KatID,
                        
                        
                    });
                    db.SaveChanges();
                }
            }

            return RedirectToAction("MakaleYaz");
        }
        public ActionResult KategoriAyarlari()
        {
            return View();
        }
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Models.ViewModel.KategoriEkle model)
        {
            var user = Session["UserInfo"] as BerkTokgozBlogSitesi.Models.ViewModel.UserInfo;
            if (ModelState.IsValid)
            {
                if (user.IsAdmin)
                {
                    db.Kategori.Add(new Models.Kategori
                    {
                        Adi = model.Adi
                    }
                    );
                    db.SaveChanges();
                }
            }

            return View();

        }

        public ActionResult KategoriDuzenle()
        {
            var list = db.Kategori.ToList();

            if (list != null)
            {
                list.Insert(0, new Models.Kategori { Adi = "Seçiniz", ID = 0 });
            }

            ViewBag.Kategoriler = list.Select(p => new SelectListItem { Text = p.Adi, Value = p.ID.ToString() }).ToList();
            return View();

        }

        [HttpPost]
        public ActionResult KategoriDuzenle(Models.ViewModel.KategoriDuzenle model)
        {
            var user = Session["UserInfo"] as BerkTokgozBlogSitesi.Models.ViewModel.UserInfo;
            if (model != null && ModelState.IsValid)
            {
                if (user != null && user.IsAdmin)
                {
                    var entity = db.Kategori.Find(model.KategoriId);
                    if (entity != null)
                    {
                        entity.Adi = model.Adi;
                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("KategoriDuzenle");
        }

        public ActionResult KategoriSil()
        {
            var list = db.Kategori.ToList();

            if (list != null)
            {
                list.Insert(0, new Models.Kategori { Adi = "Seçiniz", ID = 0 });
            }

            ViewBag.Kategoriler = list.Select(p => new SelectListItem { Text = p.Adi, Value = p.ID.ToString() }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult KategoriSil(Models.ViewModel.KategoriSil model)
        {
            var user = Session["UserInfo"] as BerkTokgozBlogSitesi.Models.ViewModel.UserInfo;
            if (model != null && ModelState.IsValid)
            {
                if (user != null && user.IsAdmin)
                {
                    var entity = db.Kategori.Find(model.KategoriId);
                    if (entity != null)
                    {
                        db.Kategori.Remove(entity);
                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("KategoriSil");
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            return View();
        }

        public ActionResult Sayfalar()
        {
            return View();
        }

        public ActionResult Uyeler()
        {
            return View();
        }
        public ActionResult UyeDuzenle()
        {
            var list = db.Kullanici.ToList();

            if (list != null)
            {
                list.Insert(0, new Models.Kullanici { Adi = "Seçiniz", ID = 0 });
            }

            ViewBag.Uyeler = list.Select(p => new SelectListItem { Text = p.Adi, Value = p.ID.ToString() }).ToList();
            return View();


        }
        [HttpPost]
        public ActionResult UyeDuzenle(Models.ViewModel.UyeDuzenle model)
        {
            var user = Session["UserInfo"] as BerkTokgozBlogSitesi.Models.ViewModel.UserInfo;
            if (model != null && ModelState.IsValid)
            {
                if (user != null && user.IsAdmin)
                {
                    var entity = db.Kullanici.Find(model.ID);
                    if (entity != null)
                    {
                        entity.Adi = model.Adi;
                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("UyeDuzenle");

        }
        public ActionResult UyeSil()
        {
            var list = db.Kullanici.ToList();

            if (list != null)
            {
                list.Insert(0, new Models.Kullanici { Adi = "Seçiniz", ID = 0 });
            }

            ViewBag.Uyeler = list.Select(p => new SelectListItem { Text = p.Adi, Value = p.ID.ToString() }).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult UyeSil(Models.ViewModel.UyeSil model)
        {
            var user = Session["UserInfo"] as BerkTokgozBlogSitesi.Models.ViewModel.UserInfo;
            if (model != null && ModelState.IsValid)
            {
                if (user != null && user.IsAdmin)
                {
                    var entity = db.Kullanici.Find(model.ID);
                    if (entity != null)
                    {
                        db.Kullanici.Remove(entity);
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("UyeSil");
        }

        public ActionResult UyeRol()
        {
            var uyeler = db.Kullanici.ToList();
            var roller = db.Rol.ToList();
            ViewBag.Uyeler = uyeler.Select(p => new SelectListItem { Text = p.Nick, Value = p.ID.ToString() }).ToList();
            ViewBag.Roller = roller.Select(p => new SelectListItem { Text = p.RolKod, Value = p.ID.ToString() }).ToList();

            return View(new UyeRol());
        }

        [HttpPost]
        public ActionResult UyeRol(UyeRol model)
        {
            var user = Session["UserInfo"] as BerkTokgozBlogSitesi.Models.ViewModel.UserInfo;

            if (user != null && user.IsAdmin)
            {
                if (model != null)
                {
                    var uye = db.Kullanici.Find(model.UyeId);

                    if (uye != null)
                    {
                        uye.RolID = model.RolId;
                        db.SaveChanges(); 
                    }
                }
            }
            
            return RedirectToAction("UyeRol");
        }
        public ActionResult MakaleSil()
        {
            var list = db.Makale.ToList();

            if (list != null)
            {
                list.Insert(0, new Models.Makale { Baslik = "Seçiniz", ID = 0 });
            }

            ViewBag.Makaleler = list.Select(p => new SelectListItem { Text = p.Baslik, Value = p.ID.ToString() }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult MakaleSil(Models.ViewModel.MakaleSil model)
        {

            var user = Session["UserInfo"] as BerkTokgozBlogSitesi.Models.ViewModel.UserInfo;
            if (model != null && ModelState.IsValid)
            {
                if (user != null && user.IsAdmin)
                {
                    var entity = db.Makale.Find(model.MakaleID);
                    if (entity != null)
                    {
                        db.Makale.Remove(entity);
                        db.SaveChanges();
                    }
                }
            }

            return RedirectToAction("MakaleSil");
        }
        public ActionResult Makaleler()
        {
            return View();
        }
        
        public ActionResult YorumSil(int? id)
        {

            var user = Session["UserInfo"] as BerkTokgozBlogSitesi.Models.ViewModel.UserInfo;
           
            
                if (user != null && user.IsAdmin || user.Yazar)
                {
                    var entity = db.Yorum.Find(id);
                var makaleId = entity.MakaleID;
                    if (entity != null)
                    {
                        db.Yorum.Remove(entity);
                        db.SaveChanges();
                    return RedirectToAction("Detay","Makale", new { id = makaleId.Value } );
                }
                }
            

            return RedirectToAction("Anasayfa","Home");
        }
    }
    

        }