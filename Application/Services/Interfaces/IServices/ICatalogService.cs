using Application.DtoModels.Response.User;

namespace Application.Services.Interfaces.IServices
{
    public interface ICatalogService
    {
        Task<List<CategoryResponseDto>> GetCategoriesAsync();

        Task<List<SubcategoryResponseDto>> GetSubcategoriesByIdAsync(int categoryId);

        Task<List<ProductResponseDto>> GetProductsBySubcategoryIdAsync(int subcategoryId);

        Task<List<ProductResponseDto>> GetProductsByNameAsync(string productName);

        Task<List<ProductResponseDto>> GetAllProductsAsync();
    }
}
