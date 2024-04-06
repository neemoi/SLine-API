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
                Console.WriteLine($"Error in Repository -> AddProductToCartAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<List<UserCart>> GetCartItemsAsync(string userId)
        {
            try
            {
                var userExist = await _storeLineContext.Users.FirstOrDefaultAsync(i => i.Id == userId)
                    ?? throw new Exception($"User by id ({userId}) not found");

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
                Console.WriteLine($"Error in Repository -> GetCartItemsAsync: {ex.Message}");
                throw;
            };
        }

        public async Task<List<Warehouse>> GetProductsAvailableStores(int productId)
        {
            try
            {
                var productExist = await _storeLineContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId)
                    ?? throw new Exception($"Product by id ({productId}) not found");

                var result = await _storeLineContext.Warehouses
                 .Include(w => w.Store)
                     .ThenInclude(s => s.DeliveryOptions)
                 .Include(p => p.Product)
                    .ThenInclude(p => p.Warehouses)
                 .Where(w => w.ProductId == productId)
                 .ToListAsync();


                if (result.Any())
                {
                    return result;
                }
                else
                {
                    throw new InvalidOperationException($"Warehouses not found for ProductId: {productId}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Repository -> GetProductsAvailableStores: {ex.Message}");
                throw;
            }
        }

        public async Task<UserCart> RemoveProductByIdCartAsync(DeleteCartProductDto model)
        {
            try
            {
                var cartItem = await _storeLineContext.UserCarts
                    .Include(p => p.Product)
                    .FirstOrDefaultAsync(c => c.ProductId == model.ProductId && c.UserId == model.UserId);

                if (cartItem != null)
                {
                    if (cartItem.Quantity >= model.Quantity)
                    {
                        cartItem.Quantity -= model.Quantity;

                        if (cartItem.Quantity == 0)
                        {
                            _storeLineContext.UserCarts.Remove(cartItem);
                        }

                        await _storeLineContext.SaveChangesAsync();

                        return cartItem;
                    }
                    else
                    {
                        throw new Exception("Requested quantity to remove exceeds the quantity in the cart.");
                    }
                }
                else
                {
                    throw new Exception($"Product with ID {model.ProductId} not found in the user's cart.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Repository -> RemoveProductByIdCartAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<List<UserCart>> RemoveUserCartAsync(string userId)
        {
            try
            {
                var userExist = await _storeLineContext.Users.FirstOrDefaultAsync(i => i.Id == userId)
                   ?? throw new Exception($"User by id ({userId}) not found");

                var cartItems = await _storeLineContext.UserCarts
                    .Include(p => p.Product)
                    .Where(c => c.UserId == userId)
                    .ToListAsync();

                if (cartItems != null && cartItems.Any())
                {
                    _storeLineContext.UserCarts.RemoveRange(cartItems);

                    await _storeLineContext.SaveChangesAsync();
                    
                    return cartItems;
                }
                else
                {
                    throw new Exception($"User cart not found for UserId: ({userId})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Repository -> RemoveUserCartAsync: {ex.Message}");
                throw;
            }
        }

    }
}
