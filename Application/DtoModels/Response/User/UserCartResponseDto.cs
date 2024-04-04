namespace Application.DtoModels.Response.User
{
    public class UserCartResponseDto
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public decimal Price { get; set; }
        
        public int Quantity { get; set; }
    }
}
