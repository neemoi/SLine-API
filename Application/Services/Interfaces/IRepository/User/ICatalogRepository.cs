using Persistance;

namespace Application.Services.Interfaces.IRepository.User
{
    public interface ICatalogRepository
    {
        Task<List<Category>> GetCategoriesAsync();

        Task<List<Subcategory>> GetSubcategoriesByIdAsync(int categoryId);

        Task<List<Product>> GetProductsBySubcategoryIdAsync(int subcategoryId);

        Task<List<Product>> GetProductsByNameAsync(string productName);

        Task<Product> GetProductsByIdAsync(int productId);

        Task<List<Product>> GetAllProductsAsync();
    }
}
