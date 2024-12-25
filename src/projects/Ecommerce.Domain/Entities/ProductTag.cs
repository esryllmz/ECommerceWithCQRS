using Core.Persistence.Repositories;

namespace Ecommerce.Domain.Entities;

public sealed class ProductTag : Entity<Guid>
{
    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
    
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    
}