namespace Application.DtoModels.Response.User
{
    public class StoreResponseDto
    {
        public string? StoreName { get; set; }

        public string? City { get; set; }

        public string? Address { get; set; }

        public ChainOfStoreResponseDto? Chain { get; set; }
    }
}
