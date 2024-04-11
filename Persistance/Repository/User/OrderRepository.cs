using Application.DtoModels.Models.User;
using Application.Services.Interfaces.IRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repository.User
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreLineContext _storeLineContext;
        private readonly IMapper _mapper;

        public OrderRepository(StoreLineContext storeLineContext, IMapper mapper)
        {
            _storeLineContext = storeLineContext;
            _mapper = mapper;
        }

        public async Task<Order> CreateOrderAsync(CreateOrder model)
        {
            try
            {
                var userCart = await _storeLineContext.UserCarts
                    .Include(c => c.Store)
                    .Include(c => c.User)
                    .Include(c => c.Orders)
                        .ThenInclude(c => c.Delivery)
                    .Include(c => c.Product)
                    .Where(c => c.UserId == model.UserId && c.StoreId == model.StoreId)
                    .ToListAsync();

                if (!userCart.Any())
                {
                    throw new Exception($"User id ({model.UserId}) has no items for store id ({model.StoreId}) in the cart.");
                }

                if (userCart.Any(c => !c.IsOrdered))
                {
                    var order = _mapper.Map<Order>(model);
                    order.OrderDate = DateTime.Now;
                    order.CartId = userCart.First().CartId;

                    foreach (var cartItem in userCart)
                    {
                        var orderItem = new OrderItem
                        {
                            ProductId = cartItem.ProductId,
                            Quantity = cartItem.Quantity,
                            ProductPrice = cartItem.Price,
                            TotalPrice = cartItem.Price * cartItem.Quantity,
                            Store = cartItem.Store.StoreName
                        };

                        order.OrderItems.Add(orderItem);
                    }

                    _storeLineContext.Orders.Add(order);

                    await _storeLineContext.SaveChangesAsync();

                    foreach (var cartItem in userCart)
                    {
                        cartItem.IsOrdered = true;
                    }

                    await _storeLineContext.SaveChangesAsync();

                    return order;
                }
                else
                {
                    throw new Exception($"All items in the cart for user id ({model.UserId}) and store id ({model.StoreId}) are already ordered.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create order: {ex.Message}");
            }
        }
    }
}
