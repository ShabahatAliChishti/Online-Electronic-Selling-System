using Electronics_Selling_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace Electronics_Selling_System.Controllers
{
    public class UserAccountController : Controller
    {
        tbl_User usm = new tbl_User();
        [HttpGet]
        public ActionResult Register()
        {
            return View(usm);
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


        [HttpGet]
        public ActionResult Login()
        {
            Session["Loginaccess"] = "no";
            //Session["Loginaccess"] = "ok";
            return View();
        }

        [HttpPost]
        public ActionResult Login(tbl_User user)
        {

            //ElectronicsDbEntities db = new ElectronicsDbEntities();
            int logincheck = user.GetPassword();
            Session["loginname"] = user.User_FirstName;
            Session["u_id"] = user.User_ID;
            // bool isValid = db.tbl_User.Any(x => x.User_Email == user.User_Email && x.User_Password == user.User_Password );
            //bool isValid = context.User.Any(x => x.UserName == model.UserName && x.Password == model.Password);
            //if (isValid)
            if (logincheck == 1)
            {

                Session["loginaccess"] = "ok";
                // Session["u_id"] = user.User_ID;
                // FormsAuthentication.SetAuthCookie(user.User_Email, false);
                return RedirectToAction("Admin", "Home");
            }

            else if (logincheck == 2)
            {
                return RedirectToAction("Index", "SearchProducts");
            }
            else
                return View();
        }
    }
}



            //string logincheck = user.User_Email;
            //if (use > 0)
            //{

//    if (logincheck == "shabahatali@gmail.com")
//    {
//        Session["Loginaccess"] = "ok";
//        return RedirectToAction("Admin", "Home");

//    }
//    else
//    {
//        return RedirectToAction("Customer");
//    }


//}




//            else
//            {
//                return View();
//            }
//        }

//    }
//}
