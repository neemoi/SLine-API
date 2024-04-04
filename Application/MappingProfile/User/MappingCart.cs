using Application.DtoModels.Models.User;
using Application.DtoModels.Response.User;
using AutoMapper;
using Persistance;

namespace Application.MappingProfile.User
{
    public class MappingCart : Profile
    {
        public MappingCart()
        {
            CreateMap<CartDto, UserCartResponseDto>();
            CreateMap<CartDto, UserCart>();
            CreateMap<UserCart, UserCartResponseDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName));
        }
    }
}
