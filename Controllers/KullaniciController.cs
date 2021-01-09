using BerkTokgozBlogSitesi.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BerkTokgozBlogSitesi.Controllers
{
    public class KullaniciController : Controller
    {

        BerkTokgozBlogSitesi.Models.BerkTokgoz_BlogEntities db  = new Models.BerkTokgoz_BlogEntities();
        // GET: Kullanici
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(KayitOlViewModel model)
            {
            if (ModelState.IsValid)
            {
                db.Kullanici.Add(new Models.Kullanici
                {
                    Sifre = model.Sifre,
                    Nick = model.Nick,
                    Mail = model.Mail,
                    RolID= 2,
                    Adi=model.Adi,
                    Soyadi=model.Soyadi,
                    KayitTarihi = DateTime.Now
                    
                     
            });
                db.SaveChanges();
                return RedirectToAction("Anasayfa", "Home");
            }


            else
            {
                return View();
            }

        }

        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(LoginViewModel model)
        {
            if (model?.username != null && model.password != null)
            {
                var user = db.Kullanici.FirstOrDefault(p => p.Nick == model.username && p.Sifre == model.password);

                if (user != null)
                {
                    var userInfo = new UserInfo
                    {
                        IsAdmin = user.Rol.RolKod == "ADM" ? true : false,
                        UserName = user.Nick,
                        Yazar = user.Rol.RolKod == "YZR" ? true : false,
                        Uye = user.Rol.RolKod == "UYE" ? true : false,
                        Id = user.ID
                    };

                    Session["UserInfo"] = userInfo;
                }
                else
                {
                    ViewData["Message"] = "Kullanıcı bulunamadı";
                    return View();
                }
            }
            else
            {
                return View();
            }

            return RedirectToAction("Anasayfa", "Home");
        }
        public ActionResult Cikis()
        {
            Session["UserInfo"] = null;
            return RedirectToAction("Anasayfa", "Home");
        }
        public ActionResult ProfilAyarlari()
        {
            return View();
        }
        public ActionResult Mesajlar()
        {
            return View();
        }
    }
}