using Application.DtoModels.Models.User;

namespace Application.DtoModels.Response.User
{
    public class SubcategoryResponseDto
    {
        public int SubcategoryId { get; set; }

        public string? SubcategoryName { get; set; }

        public int CategoryId { get; set; }

        public List<ProductDto>? Products { get; set; }
    }
}
