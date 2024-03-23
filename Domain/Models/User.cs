using Microsoft.AspNetCore.Identity;

namespace Persistance;

public partial class User : IdentityUser
{
    public string? Address { get; set; }

    public virtual ICollection<UserCart> UserCarts { get; set; } = new List<UserCart>();

    public virtual ICollection<UserClaim> AspNetUserClaims { get; set; } = new List<UserClaim>();

    public virtual ICollection<UserLogin> AspNetUserLogins { get; set; } = new List<UserLogin>();

    public virtual ICollection<UserToken> AspNetUserTokens { get; set; } = new List<UserToken>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
