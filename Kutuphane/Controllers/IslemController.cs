using Kutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kutuphane.Controllers
{
    public class IslemController : Controller
    {
        kutuphaneEntities db = new kutuphaneEntities();
        public ActionResult Index()
        {
            return View(db.hareket.Where(x => x.islemdurum == true).ToList());
        }
    }
}