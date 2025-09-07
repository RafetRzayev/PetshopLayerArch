using AutoMapper;
using Petshop.BLL.ViewModels;
using Petshop.DAL.DataContext.Entities;

namespace Petshop.BLL.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryViewModel>().ReverseMap();
        CreateMap<Category, CreateCategoryViewModel>().ReverseMap();
        CreateMap<Category, UpdateCategoryViewModel>().ReverseMap();

        CreateMap<Product, ProductViewModel>()
            .ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category == null ? "" : src.Category.Name))
            .ForMember(x => x.ImageNames, opt => opt.MapFrom(src => src.Images.Select(i => i.ImageName).ToList()))
            .ForMember(x => x.TagNames, opt => opt.MapFrom(src => src.ProductTags.Select(t => t.Tag != null ? t.Tag.Name : "").ToList()))
            .ReverseMap();

        CreateMap<Product, CreateProductViewModel>().ReverseMap();
        CreateMap<Product, UpdateProductViewModel>().ReverseMap();

        CreateMap<Review, CreateReviewViewModel>().ReverseMap();
        CreateMap<Review, UpdateReviewViewModel>().ReverseMap();
        CreateMap<Review, ReviewViewModel>()
            .ForMember(x => x.ProductName, opt => opt.MapFrom(src => src.Product == null ? "" : src.Product.Name))
            .ForMember(x => x.AppUserName, opt => opt.MapFrom(src => src.AppUser == null ? "" : src.AppUser.UserName))
            .ForMember(x => x.AppUserProfileImageName, opt => opt.MapFrom(src => src.AppUser == null ? "" : src.AppUser.ProfileImageName))
            .ReverseMap();
    }
}
