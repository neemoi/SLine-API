using Application.DtoModels.Response.User.Store;
using AutoMapper;
using Persistance;

namespace Application.MappingProfile.User
{
    public class MappingStore : Profile
    {
        public MappingStore()
        {
            CreateMap<Store, StoreResponseDto>();
            CreateMap<ChainOfStore, ChainOfStoreResponseDto>();
        }
    }
}
