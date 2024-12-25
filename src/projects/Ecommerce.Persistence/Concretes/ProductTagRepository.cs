using Core.Persistence.Repositories;
using Ecommerce.Application.Services.Repositories;
using Ecommerce.Domain.Entities;
using Ecommerce.Persistence.Contexts;

namespace Ecommerce.Persistence.Concretes;

public class ProductTagRepository:EfRepositoryBase<ProductTag,Guid,BaseDbContext>,IProductTagRepository
{
    public ProductTagRepository(BaseDbContext context) : base(context)
    {
    }
}