using Application.DtoModels.Models.User.Category;
using Application.DtoModels.Response.User;
using AutoMapper;
using Persistance;

namespace Application.MappingProfile.User
{
    public class MappingCatalog : Profile
    {
        public MappingCatalog()
        {
            CreateMap<Category, CategoryResponseDto>()
                .ForMember(dest => dest.Subcategories, opt => opt.MapFrom(src => src.Subcategories.ToList()));
            CreateMap<Subcategory, SubcategoryResponseDto>();
            CreateMap<Subcategory, SubcategoryDto>();
            CreateMap<Product, ProductResponseDto>();
        }
    }
}
