using Electronics_Selling_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Electronics_Selling_System.Controllers
{
    public class SearchProductsController : Controller
    {
        // GET: SearchProducts
        ElectronicsDbEntities db = new ElectronicsDbEntities();
        public ActionResult Index()
        {
            if (TempData["cart"] != null)
            {
                float x = 0;
                List<Cart> li2 = TempData["cart"] as List<Cart>;
                foreach (var item in li2)
                {
                    x += item.bill;

                }

                TempData["total"] = x;
            }
            TempData.Keep();
            return View(db.tbl_Product.OrderByDescending(x => x.Product_ID).ToList());
        }
    }
}