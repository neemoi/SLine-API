using Persistance;

namespace Application.Services.Interfaces.IRepository
{
    public interface ICatalogRepository
    {
        Task<List<Category>> GetCategoriesAsync();

        Task<List<Subcategory>> GetSubcategoriesByIdAsync(int categoryId);

        Task<List<Product>> GetProductsBySubcategoryIdAsync(int subcategoryId);

        Task<List<Product>> GetProductsByNameAsync(string productName);

        Task<List<Product>> GetAllProductsAsync();
    }
}
