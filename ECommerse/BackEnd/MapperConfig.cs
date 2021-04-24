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
            //
            CreateMap<Rating,RatingVM>()
                .ForMember(item => item.UserName, opt => opt.MapFrom(item => item.User.UserName));
            CreateMap<RatingVM,Rating>();
            //
            CreateMap<User, UserVM>();
        }
    }
}