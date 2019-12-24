/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stktakip.Models;
namespace stktakip.Controllers
{
    public class uyeolController : Controller
    {
        StokTakipEntities db = new StokTakipEntities();
        // GET: uyeol
        
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        

        string kadi = "", sifre = "";
         public ActionResult Login(LoginController lg1)
        {
            Login user = new Login() { UserName = kadi, Password = sifre };
            db.Login.Add(user);
            db.SaveChanges();
            return View();
        }
    }

}
*/
