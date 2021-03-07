using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class VitrinController : Controller
    {
        kutuphaneEntities db = new kutuphaneEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(iletisim i)
        {
            db.iletisim.Add(i);
            db.SaveChanges();
            return View(i);
        }
    }
}