using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
namespace Kutuphane.Controllers
{
    public class KategoriController : Controller
    {
        kutuphaneEntities db = new kutuphaneEntities();
        // GET: Kategori
        public ActionResult Index()
        {
            return View(db.kategori.ToList());
        }
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(kategori yeni)
        {
            if (ModelState.IsValid)
            {
                db.kategori.Add(yeni);
                db.SaveChanges();
                ViewBag.Durum = "Success";
                return View();
            }
            ViewBag.Durum = "Danger";
            return View(yeni);
        }
        public ActionResult sil(int id)
        {
            var bul = db.kategori.Find(id);
            if(bul!= null) { 
            db.kategori.Remove(bul);
            db.SaveChanges();
                ViewBag.Mesaj = "<script>window.alert('Silme İşlemi Gerçekleştirilemedi!');</script>";
                //return RedirectToAction("index");
            }
            return RedirectToAction("index");
        }
        public ActionResult Guncelle(int id)
        {
            var bul = db.kategori.Where(x => x.id == id).SingleOrDefault();
            return View(bul);
        }
        [HttpPost]
        public ActionResult Guncelle(kategori k,int id)
        {
            if (ModelState.IsValid) { 
            var bul = db.kategori.Where(x => x.id == id).SingleOrDefault();
            bul.ad = k.ad;
            db.SaveChanges();
            return RedirectToAction("index");
            }
            return View(k);
        }
    }
}