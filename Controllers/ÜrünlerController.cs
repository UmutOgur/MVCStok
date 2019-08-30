using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
   
    public class ÜrünlerController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: Ürünler
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TBLURUNLER.ToList();
            var degerler=db.TBLURUNLER.ToList().ToPagedList(sayfa,5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Urunekle()
        {
            //DropDownList Kullanımı
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()

                                                }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
       
        [HttpPost]
        public ActionResult Urunekle(TBLURUNLER p1)
        {
            var ktg=db.TBLKATEGORILER.Where (m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SİL(int id)
        {
            var degerler = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(degerler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ÜrünGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
             return View("ÜrünGetir", urun);
        }
        public ActionResult Güncelle(TBLURUNLER p1)
        {
            var guncelle = db.TBLURUNLER.Find(p1.URUNID);
            guncelle.URUNAD = p1.URUNAD;
            guncelle.URUNMARKA = p1.URUNMARKA;
            guncelle.URUNKATEGORİ = p1.URUNKATEGORİ;
            guncelle.URUNFIYAT = p1.URUNFIYAT;
            guncelle.URUNSTOK = p1.URUNSTOK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}