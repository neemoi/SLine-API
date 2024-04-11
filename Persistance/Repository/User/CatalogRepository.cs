using Application.Services.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repository.User
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly StoreLineContext _storeLineContext;

        public CatalogRepository(StoreLineContext storeLineContext)
        {
            _storeLineContext = storeLineContext;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                var products = await _storeLineContext.Products.ToListAsync();

                if (products != null)
                {
                    return products;
                }
                else
                {
                    throw new Exception($"Products not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            };
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                var categories = await _storeLineContext.Categories
                   .Include(c => c.Subcategories) 
                   .ToListAsync();

                if (categories != null)
                {
                    return categories;
                }
                else
                {
                    throw new Exception($"Categories not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            };
        }

        public async Task<Product> GetProductsByIdAsync(int productId)
        {
            try
            {
                var product = await _storeLineContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
                  
                if (product != null)
                {
                    return product;
                }
                else
                {
                    throw new Exception($"Product Id ({productId}) not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        public async Task<List<Product>> GetProductsByNameAsync(string productName)
        {
            try
            {
                var products = await _storeLineContext.Products
                    .Where(p => p.ProductName.Contains(productName))
                    .ToListAsync();

                if (products != null)
                {
                    return products;
                }
                else
                {
                    throw new Exception($"Product name ({productName}) not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        public async Task<List<Product>> GetProductsBySubcategoryIdAsync(int subcategoryId)
        {
            try
            {
                var products = await _storeLineContext.Products
                    .Where(p => p.SubcategoryId == subcategoryId)
                    .ToListAsync();

                if (products != null)
                {
                    return products;
                }
                else
                {
                    throw new Exception($"Products with subcategoryId ({subcategoryId}) not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }

        public async Task<List<Subcategory>> GetSubcategoriesByIdAsync(int categoryId)
        {
            try
            {
                var subcategories = await _storeLineContext.Subcategories
                    .Where(s => s.CategoryId == categoryId)
                    .ToListAsync();

                if (subcategories != null)
                {
                    return subcategories;
                }
                else
                {
                    throw new Exception($"Subcategory with categoryId ({categoryId}) not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                throw;
            }
        }
    }
}
