using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Osus.Core;
using OsusTattoo.Models;
using OsusTattoo.WebApp.Models;

namespace OsusTattoo.WebApp.Helper
{
    public class MapperConfig
    {
        public static Mapper InitializeAutomapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserModel, User>().ReverseMap();
                cfg.CreateMap<RegisterViewModel, User>().ReverseMap();
                cfg.CreateMap<AllProductsViewModel, Product>().ReverseMap();
                cfg.CreateMap<ProductsModel, Product>().ReverseMap();
                cfg.CreateMap<ProductDetailsModel, Product>().ReverseMap();
            });

            Mapper mapper = new Mapper(config);
            return mapper;
        }
    }
}