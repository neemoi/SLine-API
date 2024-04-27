using Application.DtoModels.Models.User.Category;
using Application.DtoModels.Models.User.Product;
using Application.DtoModels.Response.User.CategorySbcategory;
using Application.DtoModels.Response.User.Product;
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

            CreateMap<Subcategory, SubcategoryResponseDto>()
                .ForMember(dest => dest.SubcategoryName, opt => opt.MapFrom(src => src.SubcategoryName));

            CreateMap<Subcategory, SubcategoryDto>();

            CreateMap<Product, ProductResponseDto>()
                .ForMember(dest => dest.SubcategoryName, opt => opt.MapFrom(src => src.Subcategory.SubcategoryName));

            CreateMap<Warehouse, PriceRangeDto>();

            CreateMap<PriceRangeDto, PriceRangeResponseDto>();
        }
    }
}
