namespace Application.DtoModels.Models.User
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
        
        public List<SubcategoryDto>? Subcategories { get; set; }
    }
}
