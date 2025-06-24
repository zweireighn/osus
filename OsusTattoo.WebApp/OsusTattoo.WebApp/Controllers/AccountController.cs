using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Osus.Business;
using Osus.Core;
using OsusTattoo.Models;
using OsusTattoo.WebApp.Helper;

namespace OsusTattoo.WebApp.Controllers
{
    public class AccountController : Controller
    {
        UserBusiness _userBusiness;
        Mapper mapper;

        public AccountController() 
        {
            mapper = MapperConfig.InitializeAutomapper();
            _userBusiness = new UserBusiness();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            User userInfo = _userBusiness.LoadUserByUserName(model.Email);

            Session["UserInfo"] = userInfo;

            if (userInfo.Password != model.Password)
            {
                ModelState.AddModelError("Password", "Incorrect Password");
                return View();
            }

            if ((bool)Session["FromCheckout"])
            {
                Session["FromCheckout"] = null;
                //Update Order using sessionid then insert the userid in
                //the order to associate the order to the current logged user
                return RedirectToAction("CheckoutItems", "Checkout");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            model.UserRole = Osus.Core.Enums.UserRole.NormalUser;

            User user = mapper.Map<User>(model); 

            _userBusiness.StoreUser(user);

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}