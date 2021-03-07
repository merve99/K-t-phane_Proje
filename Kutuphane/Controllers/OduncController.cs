using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class OduncController : Controller
    {
        kutuphaneEntities db = new kutuphaneEntities();
        public ActionResult Index()
        {
            
            return View(db.hareket.Where(x => x.islemdurum == false).ToList());
        }
        public ActionResult Oduncver()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Oduncver(hareket h)
        {
            h.islemdurum = false;
            db.hareket.Add(h);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Odunciade(int id)
        {
            var bul = db.hareket.Where(x=>x.id==id).SingleOrDefault();
            DateTime d1 = DateTime.Parse(bul.iadetarih.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View(bul);
        }
        [HttpPost]
        public ActionResult Odunciade(hareket h,int id)
        {
            var bul = db.hareket.Where(x=>x.id==id).SingleOrDefault();
            bul.uyegetirtarih = h.uyegetirtarih;
            bul.islemdurum = true;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}