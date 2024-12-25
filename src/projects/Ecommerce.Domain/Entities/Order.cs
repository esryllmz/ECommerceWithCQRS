using Core.Persistence.Repositories;

namespace Ecommerce.Domain.Entities;

public sealed class Order : Entity<Guid>
{
    public int UserId { get; set; }
    public AppUser User { get; set; }

    public decimal Total { get; set; }  
    public ICollection<OrderItem> OrderItems { get; set; }
}