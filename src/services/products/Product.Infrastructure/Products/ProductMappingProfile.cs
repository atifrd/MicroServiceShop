using AutoMapper;
using Product.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using productModel = Product.Domain.Products;

namespace Product.Infrastructure.Products
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<productModel.Product, ProductReqDto>().ReverseMap();
            CreateMap<productModel.Product, ProductResDto>().ForMember(dest => dest.CategoryTitle_Id,
                config => config.MapFrom(src => $"{src.Category.Title}({src.CategoryId})")
                ).ReverseMap();
        }
    }
}