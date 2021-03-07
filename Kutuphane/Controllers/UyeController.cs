using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace Kutuphane.Controllers
{
    public class UyeController : Controller
    {
        kutuphaneEntities db = new kutuphaneEntities();
        public ActionResult Index(int sayfa=1)
        {
            return View(db.uyeler.ToList().ToPagedList(sayfa,6));
        }
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(uyeler uye)
        {
            db.uyeler.Add(uye);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Sil(int id)
        {
            var bul = db.uyeler.Where(x => x.id == id).SingleOrDefault();
            db.uyeler.Remove(bul);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Guncelle(int id)
        {
            var bul = db.uyeler.Where(x => x.id == id).FirstOrDefault();
            return View(bul);
        }
        [HttpPost]
        public ActionResult Guncelle(int id,uyeler uye)
        {
            var bul = db.uyeler.Where(x => x.id == id).SingleOrDefault();
            bul.ad = uye.ad;
            bul.soyad = uye.soyad;
            bul.mail = uye.mail;
            bul.kullaniciadi = uye.kullaniciadi;
            bul.mail = uye.mail;
            bul.okul = uye.okul;
            bul.sifre = uye.sifre;
            bul.telefon = uye.telefon;
            bul.fotograf = uye.fotograf;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}