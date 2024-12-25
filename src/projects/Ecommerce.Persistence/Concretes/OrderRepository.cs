using Core.Persistence.Repositories;
using Ecommerce.Application.Services.Repositories;
using Ecommerce.Domain.Entities;
using Ecommerce.Persistence.Contexts;

namespace Ecommerce.Persistence.Concretes;

public class OrderRepository:EfRepositoryBase<Order,Guid,BaseDbContext>,IOrderRepository
{
    public OrderRepository(BaseDbContext context) : base(context)
    {
    }
}