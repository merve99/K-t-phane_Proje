using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class YazarController : Controller
    {
        kutuphaneEntities db = new kutuphaneEntities();
        public ActionResult Index()
        {
            return View(db.yazar.ToList());
        }
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(yazar y)
        {
            
            db.yazar.Add(y);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Sil(int id)
        {
            var bul = db.yazar.Where(x=>x.id==id).SingleOrDefault();
            db.yazar.Remove(bul);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Guncelle(int id)
        {
            var bul = db.yazar.Where(x => x.id == id).SingleOrDefault();
            return View(bul);
        }
        [HttpPost]
        public ActionResult Guncelle(yazar y,int id) {
            var bul = db.yazar.Where(x => x.id == id).SingleOrDefault();
            bul.ad = y.ad;
            bul.soyad = y.soyad;
            bul.detay = y.detay;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}