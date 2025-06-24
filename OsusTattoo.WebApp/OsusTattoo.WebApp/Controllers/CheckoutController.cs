using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Osus.Business;
using Osus.Core;
using OsusTattoo.Models;
using OsusTattoo.WebApp.Helper;

namespace OsusTattoo.WebApp.Controllers
{
    public class CheckoutController : Controller
    {
        public ActionResult CheckoutItems()
        {
            if ((User)Session["UserInfo"] == null)
            {
                Session["FromCheckout"] = true;
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}