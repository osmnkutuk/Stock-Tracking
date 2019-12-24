using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stktakip.Models;
using System.Web.Security;

namespace stktakip.Controllers
{
    public class SecurityController : Controller
    {
        StokTakipEntities2 db = new StokTakipEntities2();

        // GET: Security
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Login s1)
        {

            var kullaniciInDb = db.Login.FirstOrDefault(x => x.UserName == s1.UserName && x.Password == s1.Password);
            if( kullaniciInDb!=null)
            {
                FormsAuthentication.SetAuthCookie(kullaniciInDb.UserName, false);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.mesaj = "Geçersiz Kullanıcı Adı veya şifre";
                return RedirectToAction("Login");
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}