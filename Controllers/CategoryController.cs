using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Electronics_Selling_System.Controllers
{
    public class CategoryController : Controller
    {
        private ElectronicsDbEntities db = new ElectronicsDbEntities();

        // GET: Category
        public ActionResult Index()
        {
            var list = db.tbl_Product_Category.ToList();
         
               return View(list);
            

           
           
        }
        [HttpGet]
        public ActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Product_Category category)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Product_Category.Add(category);
                db.SaveChanges();
                
            }

            return View(category);
        }

    }
    }
