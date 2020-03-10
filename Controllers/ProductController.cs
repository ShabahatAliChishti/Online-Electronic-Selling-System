using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Security;
namespace Electronics_Selling_System.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private ElectronicsDbEntities db = new ElectronicsDbEntities();

     
        public ActionResult Index()
        {
            var list = db.tbl_Product.ToList();
            return View(list);




        }
        [HttpGet]
        public ActionResult Create()
        {
            tbl_Product products = new tbl_Product();
            //int user = User.Identity.GetUserId<int>();
            //product.User_ID = user;
        
            if (Convert.ToString(Session["Loginaccess"]) == "ok")
               {
             
                products.User_ID = Convert.ToInt32(Session["u_id"]);
                ViewBag.Product_CategoryID = new SelectList(db.tbl_Product_Category, "Product_CategoryID", "Product_CategoryName");
                //return View(product);
                return View(products);
            }

            return RedirectToAction("Admin", "Home");
        }
           
        
        //Bind(Include = "Product_ID,Product_Name,Product_Image,Product_Cost,Product_Description,Product_CategoryID,User_ID")] 
        [HttpPost]
        public ActionResult Create(tbl_Product products)
        {

            products.User_ID = Convert.ToInt32(Session["u_id"]);
            try
            {
               
               

                HttpPostedFileBase photo = Request.Files["Imagepath"];
                if (photo != null && photo.ContentLength > 0)
                {
                    var fileName = new Random().Next(100000000, 999999999) + Path.GetFileName(photo.FileName);
                    photo.SaveAs(Path.Combine(Server.MapPath("~") + "/Image/", fileName));
                    products.Product_Image = Path.Combine("/Image/", fileName);
                }
               // products.User_ID = 1;
                if (ModelState.IsValid)
                {
                   
                    //var userid = 1;
                    //products.User_ID = userid;

                    db.tbl_Product.Add(products);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Product_CategoryID = new SelectList(db.tbl_Product_Category, "Product_CategoryID", "Product_CategoryName", products.Product_CategoryID);
            }
            catch(Exception ex)
            {
                //something went wrong
            }
            return View(products);
        }
        ////string Filename = Path.GetFileName(products.Imagepath.FileName);
        //string Filename = Path.GetFileNameWithoutExtension(products.Imagepath.FileName);
        //    string extension = Path.GetExtension(products.Imagepath.FileName);
        //     Filename = Filename + DateTime.Now.ToString("yymmssfff") + extension;
        //    products.Product_Image = "~/Image/" + Filename;
        //    Filename = Path.Combine(Server.MapPath("~/Image/"), Filename);
        //    products.Imagepath.SaveAs(Filename);
            
                
        //        db.tbl_Product.Add(products);
        //        db.SaveChanges();
            
            

           
           
        }

    }

    