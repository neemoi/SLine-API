namespace Application.DtoModels.Models.User
{
    public class CartDto
    {
        public string? UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int StoreId { get; set; }
    }
}
