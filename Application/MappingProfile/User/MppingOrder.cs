using Application.DtoModels.Models.User.Order;
using AutoMapper;
using Persistance;
using YourNamespace.DtoModels.Response;

namespace Application.MappingProfile.User
{
    public class MppingOrder : Profile
    {
        public MppingOrder()
        {
            CreateMap<CreateOrder, Order>();
            CreateMap<Order, CreateOrder>();
            CreateMap<UserCart, OrderItem>()
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Store, opt => opt.MapFrom(src => src.Store.StoreName));
            CreateMap<Order, OrderResponseDto>()
                .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.CartId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Cart.User.Id))
                .ForMember(dest => dest.DeliveryId, opt => opt.MapFrom(src => src.DeliveryId))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Cart.ProductId))
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.Cart.Store.StoreId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Cart.Product.ProductName))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Cart.Price))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Cart.Quantity))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Cart.User.UserName))
                .ForMember(dest => dest.UserAddress, opt => opt.MapFrom(src => src.Cart.User.Address))
                .ForMember(dest => dest.UserPhone, opt => opt.MapFrom(src => src.Cart.User.PhoneNumber))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.DeliveryType, opt => opt.MapFrom(src => src.Delivery.DeliveryType))
                .ForMember(dest => dest.DeliveryPrice, opt => opt.MapFrom(src => src.Delivery.DeliveryPrice))
                .ForMember(dest => dest.DeliveryTime, opt => opt.MapFrom(src => src.Delivery.DeliveryTime));
        }
    }
}
