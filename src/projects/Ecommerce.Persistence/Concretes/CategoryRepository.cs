
using Core.Persistence.Repositories;
using Ecommerce.Application.Services.Repositories;
using Ecommerce.Domain.Entities;
using Ecommerce.Persistence.Contexts;
namespace Ecommerce.Persistence.Concretes;

public class CategoryRepository : EfRepositoryBase<Category, int, BaseDbContext>,ICategoryRepository
{
    public CategoryRepository(BaseDbContext context) : base(context)
    {
    }
}
