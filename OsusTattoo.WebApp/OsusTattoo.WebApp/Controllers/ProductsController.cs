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

namespace OsusTattoo.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        ProductBusiness _productBusiness;
        Mapper mapper;

        public ProductsController()
        {
            mapper = MapperConfig.InitializeAutomapper();
            _productBusiness = new ProductBusiness();
        }

        public ActionResult AllProducts()
        {
            List<Product> product = _productBusiness.LoadProduct();

            AllProductsViewModel viewModel = new AllProductsViewModel();

            viewModel.Products = mapper.Map<List<Product>, List<ProductsModel>>(product);

            return View(viewModel);
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