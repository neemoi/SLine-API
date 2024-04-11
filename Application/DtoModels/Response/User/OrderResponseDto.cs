namespace YourNamespace.DtoModels.Response
{
    public class OrderResponseDto
    {
        public int CartId { get; set; }

        public string? UserId { get; set; }

        public int? DeliveryId { get; set; }

        public int StatusId { get; set; }

        public int ProductId { get; set; }

        public int StoreId { get; set; }

        public string? ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        public string? UserName { get; set; }

        public string? UserAddress { get; set; }

        public string? UserPhone { get; set; }

        public DateTime OrderDate { get; set; }

        public string? DeliveryType { get; set; }

        public decimal DeliveryPrice { get; set; }

        public int DeliveryTime { get; set; }
    }
}
