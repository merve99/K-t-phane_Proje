using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class PersonelController : Controller
    {
        kutuphaneEntities db = new kutuphaneEntities();
        public ActionResult Index()
        {
            return View(db.personel.ToList());
        }
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(personel p)
        {
            db.personel.Add(p);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Sil(int id)
        {
            var bul = db.personel.Where(x => x.id == id).SingleOrDefault();
            db.personel.Remove(bul);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Guncelle(int id)
        {
            var bul = db.personel.Where(x => x.id == id).SingleOrDefault();
            return View(bul);
        }
        [HttpPost]
        public ActionResult Guncelle(int id,personel p)
        {
            var bul = db.personel.Where(x => x.id == id).SingleOrDefault();
            bul.personel1 = p.personel1;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}