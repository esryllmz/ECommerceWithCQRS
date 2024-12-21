using Core.Persistence.Repositories;


namespace Ecommerce.Domain.Entities;

public class Category : Entity<int>
{
    public string Name { get; set; }

}
