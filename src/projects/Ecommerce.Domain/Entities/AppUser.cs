using Core.Security.Entities;

namespace Ecommerce.Domain.Entities;

public sealed class AppUser : User
{
    public   ICollection<Order> Orders { get; set; }
}