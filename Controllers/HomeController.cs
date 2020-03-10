using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Electronics_Selling_System.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_User user)
        {
            ElectronicsDbEntities db = new ElectronicsDbEntities();
            var use = db.tbl_User.Where(x => x.User_Email == user.User_Email && x.User_Password == user.User_Password ).Count();
            string logincheck = user.User_Email;
            if (use > 0)
            {

                if (logincheck == "shabahatali@gmail.com")
                {

                    return RedirectToAction("Admin");

                }
               else 
                {
                    return RedirectToAction("Customer");
                }


            }




            else
            {
                return View();
            }
        }

        public ActionResult Admin()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult AdminView()
        //{
        //    return View();
        //}
        public ActionResult Customer()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tbl_User user)
        {
            ElectronicsDbEntities db = new ElectronicsDbEntities();
            user.Role_ID = 2;
            user.AddedOn = DateTime.Now;
         
            //user.User_Gender = "Male";
            //user.User_Gender = "Female";
            //var gender=db.
            
            db.tbl_User.Add(user);
            db.SaveChanges();
            return View();
        }
        public ActionResult Dashboard()
        {
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
            {

                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }

}