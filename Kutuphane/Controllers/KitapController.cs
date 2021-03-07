using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class KitapController : Controller
    {
        kutuphaneEntities db = new kutuphaneEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.kitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(x => x.ad.Contains(p));
            }
            return View(kitaplar.Include("yazar").Include("kategori").ToList());
        }
        public ActionResult Yeni()
        {
            List<SelectListItem> deger1 = (from i in db.kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ad,
                                               Value = i.id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.yazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ad + ' ' + i.soyad,
                                               Value = i.id.ToString()
                                           }).ToList();
            ViewBag.dgr2 =deger2;
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(kitap k)
        {
            var ktg = db.kategori.Where(x => x.id == k.kategori.id).SingleOrDefault();
            var yzr = db.yazar.Where(x => x.id == k.yazar.id).SingleOrDefault();
            k.kategori = ktg;
            k.yazar = yzr;
            k.durum = true;
            db.kitap.Add(k);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Sil(int id)
        {
            var bul = db.kitap.Where(x => x.id == id).SingleOrDefault();
            db.kitap.Remove(bul);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Guncelle(int id)
        {
            var bul = db.kitap.Where(x => x.id == id).SingleOrDefault();
            List<SelectListItem> deger1 = (from i in db.kategori.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ad,
                                               Value = i.id.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.yazar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.ad + ' ' + i.soyad,
                                               Value = i.id.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View(bul);
        }
        [HttpPost]
        public ActionResult Guncelle(kitap k)
        {
            var bul = db.kitap.Find(k.id);
            bul.ad = k.ad;
            bul.basimyil = k.basimyil;
            bul.sayfa = k.sayfa;
            bul.yayinevi = k.yayinevi;
            var ktg = db.kategori.Where(x => x.id == k.kategori.id).FirstOrDefault();
            var yzr = db.yazar.Where(x => x.id == k.yazar.id).FirstOrDefault();
            bul.kategoriid = ktg.id;
            bul.yazarid = yzr.id;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}