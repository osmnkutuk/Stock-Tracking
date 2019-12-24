using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stktakip.Models;
namespace stktakip.Controllers
{
    public class ProductStockController : Controller
    {
        // GET: ProductStock
        StokTakipEntities2 db = new StokTakipEntities2();
        public ActionResult Index()
        {
            var urnstk = db.ProductStocks.ToList();
            return View(urnstk);

        }

            [HttpGet]
        public ActionResult yenistk()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Lider,S")]
        public ActionResult yenistk(ProductStocks pr1)
        {
            if(!ModelState.IsValid)
            {
                return View("yenistk");
            }
            db.ProductStocks.Add(pr1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var stk = db.ProductStocks.Where(a => a.UrunStokId == id).FirstOrDefault();
            db.ProductStocks.Remove(stk);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult stokgnc(int id)
        {
            var sktgnc = db.ProductStocks.Find(id);
            return View("stokgnc", sktgnc);
        }
        public ActionResult Guncelle(ProductStocks pr1)
        {
            var urnstk = db.ProductStocks.Find(pr1.UrunStokId);
            urnstk.Piece = pr1.Piece;
            urnstk.RecordDate = pr1.RecordDate;
            urnstk.ProductId = pr1.ProductId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}