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
            List<Product> listProduct = _productBusiness.LoadProduct();

            AllProductsViewModel viewModel = new AllProductsViewModel();

            viewModel.Products = mapper.Map<List<Product>, List<ProductsModel>>(listProduct);

            return View(viewModel);
        }

        public ActionResult ProductDetails(int id)
        {
            Product product = _productBusiness.LoadProductByProductId(id);

            ProductsModel productResult = mapper.Map<ProductsModel>(product);

            return View(productResult);
        }

        public ActionResult Cart()
        {
            return View();
        }
    }
}