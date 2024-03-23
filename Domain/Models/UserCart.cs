﻿namespace Persistance;

public partial class UserCart
{
    public int CartId { get; set; }

    public string? UserId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public int? StoreId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Product? Product { get; set; }

    public virtual Store? Store { get; set; }

    public virtual User? User { get; set; }
}
