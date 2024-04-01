using Application.DtoModels.Models.Authorization;
using Application.DtoModels.Response.Authorization;
using AutoMapper;
using Persistance;

namespace Application.MappingProfile.User
{
    public class MappingAuthorization : Profile
    { 
        public MappingAuthorization()
        {
            CreateMap<RegisterDto, Users>();
            CreateMap<Users, LoginResponseDto>();
            CreateMap<Users, RegisterResponseDto>()
               .ForMember(dest => dest.Token, opt => opt.MapFrom((src, dest, token) => token));
            CreateMap<Users, LogoutResponseDto>();
        }
    }
}
