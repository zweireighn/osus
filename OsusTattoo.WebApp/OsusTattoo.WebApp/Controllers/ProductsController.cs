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

namespace OsusTattoo.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        ProductBusiness _productBusiness;
        Mapper mapper;
        private readonly string _productRootFolder = ConfigurationManager.AppSettings["ImageRootFolder"];

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

            ProductDetailsModel productResult = mapper.Map<ProductDetailsModel>(product);

            string dir = string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, productResult.ImagePath) ;

            string[] fileArray = Directory.GetFiles(dir);
            List<string> fileName = new List<string>(); ;
                
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
    }
}