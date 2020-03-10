using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electronics_Selling_System.Models
{
    public class Cart
    {
        public int productid { get; set; }
        public string productname { get; set; }

        public float price { get; set; }
        public int qty { get; set; }
        public float bill { get; set; }
    }
}