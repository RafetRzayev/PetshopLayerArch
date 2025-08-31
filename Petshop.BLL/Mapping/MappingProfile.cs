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
            .ReverseMap();

        CreateMap<Product, CreateProductViewModel>().ReverseMap();
        CreateMap<Product, UpdateProductViewModel>().ReverseMap();
    }
}
