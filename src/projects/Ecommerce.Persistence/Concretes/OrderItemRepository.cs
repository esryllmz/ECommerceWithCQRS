using Core.Persistence.Repositories;
using Ecommerce.Application.Services.Repositories;
using Ecommerce.Domain.Entities;
using Ecommerce.Persistence.Contexts;

namespace Ecommerce.Persistence.Concretes;

public class OrderItemRepository:EfRepositoryBase<OrderItem,Guid,BaseDbContext>,IOrderItemRepository
{
    public OrderItemRepository(BaseDbContext context) : base(context)
    {
    }
}