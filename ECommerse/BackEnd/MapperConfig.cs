using AutoMapper;
using BackEnd.Models;
using Shared.ViewModel;

namespace BackEnd
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Product, ProductVM>();
            CreateMap<ProductVM, Product>();
            //
            CreateMap<Category, CategoryVM>();
            CreateMap<CategoryVM, Category>();
        }
    }
}