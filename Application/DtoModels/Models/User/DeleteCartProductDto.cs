namespace Application.DtoModels.Models.User
{
    public class DeleteCartProductDto
    {
        public string? UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
