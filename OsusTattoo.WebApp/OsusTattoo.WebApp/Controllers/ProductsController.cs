using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OsusTattoo.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult AllProducts()
        {
            return View();
        }

        public ActionResult ProductDetails()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }
    }
}