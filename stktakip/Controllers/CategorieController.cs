using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Web.Mvc;
using stktakip.Models;
using stktakip.ViewModel;

namespace stktakip.Controllers
{
    public class CategorieController : Controller
    {
        // GET: Categorie
        StokTakipEntities2 db = new StokTakipEntities2();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.Categories.ToList();
            return View(degerler);

        }
        [HttpGet]
        public ActionResult yenikategori()
        {
           
           return View();
        }
        [ValidateAntiForgeryToken]
       
        public ActionResult yenikategori(Categories k1)
        {
            if(!ModelState.IsValid)
            {
                return View("yenikategori");
            }
            Mesajviewmodel model = new Mesajviewmodel();
            //model.Message = k1.CategorieNames + "başarıyla eklendi...";
            db.Categories.Add(k1);
            db.SaveChanges();
            //model.Status = true;
            //model.LinkText = "Kategori Listesi";
            //model.Url = "/Categorie";
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var kategori = db.Categories.Where(a=>a.CategorieId==id).FirstOrDefault();
            if (kategori==null)
            {
                return HttpNotFound();
            }
            db.Categories.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        
        
        public ActionResult kategorigetir(int  id)
        {
            var ktggnc = db.Categories.Find(id);
            Categories kategori = db.Categories.Where(k => k.CategorieId == id).FirstOrDefault();
             return View("kategorigetir",ktggnc);
            
    }
        
        public ActionResult Guncelle(Categories c1)
        {
            var ktg = db.Categories.Find(c1.CategorieId);
            ktg.CategorieNames = c1.CategorieNames;
            ktg.Explanation = c1.Explanation;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
      
        
    }

    }
 