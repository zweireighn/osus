using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Osus.Business;
using Osus.Core;
using OsusTattoo.Models;
using OsusTattoo.WebApp.Helper;
using AutoMapper.QueryableExtensions;
using System.IO;
using System.Configuration;
using Microsoft.Ajax.Utilities;
using System.Web.SessionState;
using Newtonsoft.Json;

namespace OsusTattoo.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        ProductBusiness _productBusiness;
        OrderBusiness _orderBusiness;
        Mapper mapper;
        private readonly string _productRootFolder = ConfigurationManager.AppSettings["ImageRootFolder"];

        public ProductsController()
        {
            mapper = MapperConfig.InitializeAutomapper();
            _productBusiness = new ProductBusiness();
            _orderBusiness = new OrderBusiness();
        }

        public ActionResult AllProducts()
        {
            List<Product> listProduct = _productBusiness.LoadProduct();

            AllProductsViewModel viewModel = new AllProductsViewModel();

            viewModel.Products = mapper.Map<List<Product>, List<ProductsModel>>(listProduct);

            return View(viewModel);
        }

        public ActionResult ProductDetails(int pId)
        {
            Product product = _productBusiness.LoadProductByProductId(pId);

            ProductDetailsModel productResult = mapper.Map<ProductDetailsModel>(product);

            string dir = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, productResult.ImagePath) ;

            string[] fileArray = Directory.GetFiles(dir);
            List<string> fileName = new List<string>();
                
            fileArray.ForEach(x => {
                fileName.Add(Path.GetFileName(x));
            });

            productResult.ListOfImages = fileName;

            return View(productResult);
        }

        public ActionResult Cart()
        {



            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult AddToCart(int? productId, int variantId)
        {
            ProductVariation productVariation = _productBusiness.LoadProductVariationById(variantId);
            productVariation.SessionId = Convert.ToString(Session["UserSessionId"]);
            bool isAdded = _orderBusiness.AddToCart(productVariation);

            Session["ItemCount"] = Convert.ToInt32(Session["ItemCount"]) + 1;

            var returnObj = new {
                IsSuccess = isAdded,
                ItemCount = Convert.ToInt32(Session["ItemCount"])
            };

            var jsonObj = JsonConvert.SerializeObject(returnObj);

            return Json(jsonObj, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult CheckCartByVariantId(int variantId) 
        {
            int? userId = ((User)Session["UserInfo"]) == null ? (int?)null : ((Osus.Core.User)Session["UserInfo"]).Id;

            Order order = _orderBusiness.LoadOrderByVariantId(variantId, userId, Convert.ToString(Session["UserSessionId"]));

            var jsonOrder = JsonConvert.SerializeObject(order);

            return Json(jsonOrder, JsonRequestBehavior.AllowGet);
        }
    }
}