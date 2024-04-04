using Application.DtoModels.Models.User;
using Application.Services.Interfaces.IRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repository.User
{
    public class BasketReporitory : IBasketRepository
    {
        private readonly StoreLineContext _storeLineContext;
        private readonly IMapper _mapper;

        public BasketReporitory(StoreLineContext storeLineContext, IMapper mapper)
        {
            _storeLineContext = storeLineContext;
            _mapper = mapper;
        }

        public async Task<UserCart> AddProductToCartAsync(CartDto model)
        {
            try
            {
                var store = await _storeLineContext.Stores.FirstOrDefaultAsync(s => s.StoreId == model.StoreId)
                    ?? throw new Exception($"Store ({model.StoreId}) not found");

                var product = await _storeLineContext.Products
                    .Include(p => p.Warehouses)
                    .FirstOrDefaultAsync(p => p.ProductId == model.ProductId)
                    ?? throw new Exception($"Product ({model.ProductId}) not found");

                var user = await _storeLineContext.Users.FirstOrDefaultAsync(u => u.Id == model.UserId)
                    ?? throw new Exception($"User ({model.UserId}) not found");

                var existingCartItem = await _storeLineContext.UserCarts
                    .FirstOrDefaultAsync(c => c.UserId == model.UserId && c.ProductId == model.ProductId && c.StoreId == model.StoreId);

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += model.Quantity;

                    await _storeLineContext.SaveChangesAsync();

                    return existingCartItem; 
                }
                else
                {
                    var newCartItem = _mapper.Map<UserCart>(model);

                    newCartItem.Price = product.Warehouses.FirstOrDefault()?.ProductPrice;

                    await _storeLineContext.UserCarts.AddAsync(newCartItem);

                    await _storeLineContext.SaveChangesAsync();

                    return newCartItem; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        public async Task<List<UserCart>> GetCartItemsAsync(string userId)
        {
            try
            {
                var result = await _storeLineContext.UserCarts
                 .Where(c => c.UserId == userId)
                 .Include(p => p.Product)
                 .ToListAsync();

                if (result != null)
                {
                    return _mapper.Map<List<UserCart>>(result);
                }
                else
                {
                    throw new Exception($"User cart not found for UserId: ({userId})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            };
        }
    }
}
