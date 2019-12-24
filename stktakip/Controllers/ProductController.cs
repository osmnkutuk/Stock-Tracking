using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using stktakip.Models;
namespace stktakip.Controllers
    
{
    [Authorize]

    public class ProductController : Controller
    {
        // GET: Product
        StokTakipEntities2 db = new StokTakipEntities2();
        
        public ActionResult Index(int sayfa=1)
        {
            var urunler = db.Products.ToList();
            return View(urunler);
        }
        [HttpGet]
       
        public ActionResult yeniurun()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult yeniurun(Products p1)
        {
           // var urn = db.Categories.Where(m => m.CategorieId == p1.Categories.CategorieId).FirstOrDefault();
           // p1.Categories = urn;
            db.Products.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id, FormCollection form)
        {
            var urn = db.Products.Where(a => a.ProductId == id).FirstOrDefault();
            db.Products.Remove(urn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult urunguncelle(int id)
        {
            var urunguncelle = db.Products.Find(id);

            List<SelectListItem> degerler = (from i in db.Categories.ToList()
                                            select new SelectListItem
                                         {
                                                 Text = i.CategorieNames,
                                                 Value = i.CategorieId.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;


            return View("urunguncelle", urunguncelle);
        }
        //urun guncelleme işlemi yapılmaktadır urun p1 değişken adıyla aranmakta kategori tablosunda uyuştuğunda eşlendiğinde güncelleme işlemi yapılmaktadır.
        public ActionResult Guncelle(Products p1)
        {
            var gnc = db.Products.Find(p1.ProductId);
            gnc.ProductName = p1.ProductName;
            gnc.Brands = p1.Brands;
            gnc.CategorieName = p1.CategorieName;
            gnc.ProductType = p1.ProductType;
            gnc.BuyingPrice = p1.BuyingPrice;


            var ktg = db.Categories.Where(m => m.CategorieId == p1.Categories.CategorieId).FirstOrDefault();
            gnc.CategorieName = ktg.CategorieId;

            db.SaveChanges();
            return  RedirectToAction("Index");
        }  
    }
}