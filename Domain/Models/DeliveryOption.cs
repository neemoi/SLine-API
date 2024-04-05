namespace Persistance;

public partial class DeliveryOption
{
    public int Id { get; set; }

    public int? Time { get; set; }
    
    public string? Type { get; set; }

    public decimal? Price { get; set; }

    public int? StoreId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Store? Store { get; set; }
}
