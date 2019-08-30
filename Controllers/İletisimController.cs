using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    

    public class İletisimController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: İletisim
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Yeniİletişim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeniİletişim(TBLILETISIM p1)
        {
           
            db.TBLILETISIM.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}