using Core.Persistence.Repositories;
using Ecommerce.Application.Services.Repositories;
using Ecommerce.Domain.Entities;
using Ecommerce.Persistence.Contexts;

namespace Ecommerce.Persistence.Concretes;

public class ProductImageRepository:EfRepositoryBase<ProductImage,int,BaseDbContext>,IProductImageRepository
{
    public ProductImageRepository(BaseDbContext context) : base(context)
    {
    }
}