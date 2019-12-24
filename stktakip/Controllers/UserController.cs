using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stktakip.Models;

namespace stktakip.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        StokTakipEntities2 db = new StokTakipEntities2();
        public ActionResult Index( int sayfa=1)
        {
            var user = db.Users.ToList();
            return View(user);
        }

            [HttpGet]
        public ActionResult yenikullanici()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles ="Lider,S")]
        public ActionResult yenikullanici(Users k1)
        {
            if(!ModelState.IsValid)
            {
                return View("yeniKullanici");
            }
            db.Users.Add(k1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var klnci = db.Users.Where(a => a.UserId == id).FirstOrDefault();
            if(klnci==null)
            {
                return HttpNotFound();
            }
            db.Users.Remove(klnci);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult klngnc (int id)
        {
            var klngnc = db.Users.Find(id);
            return View("klngnc", klngnc);
        }
        public ActionResult Guncelle(Users u1)
        {
            var usr = db.Users.Find(u1.UserId);
            usr.Name = u1.Name;
            usr.Surname = u1.Surname;
            usr.Nickname = u1.Nickname;
            usr.Number = u1.Number;
            usr.Email = u1.Email;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}