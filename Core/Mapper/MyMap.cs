using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dto.ViewModel.Store.FeatureValueDto;
using Core.Dto.ViewModel.Store.ProductDto;
using Core.Dto.ViewModel.Store.SubCategory;
using Core.Dto.ViewModel.User;
using Data;

using Domain.Store;

namespace Core.Mapper
{
    public class MyMap:Profile
    {
        public MyMap()
        {
            CreateMap<SubCategory, SubCategoryAddVM>().ReverseMap();
            CreateMap<SubCategory, SubCategoryEditVM>().ReverseMap();
            CreateMap<FeatureValue, FeatureValueAddVM>().ReverseMap();
            CreateMap<FeatureValue, FeatureValueEditVM>().ReverseMap();


            CreateMap<Product, ProductAddVM>().ReverseMap();

            
        }
    }
}
