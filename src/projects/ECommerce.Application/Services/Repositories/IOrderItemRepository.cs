using Core.Persistence.Repositories;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services.Repositories;

public interface IOrderItemRepository: IAsyncRepository<OrderItem,Guid>
{
    
}