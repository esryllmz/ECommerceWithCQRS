

using Core.Persistence.Repositories;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Persistence.Abstracts;

public interface ICategoryRepository : IAsyncRepository<Category,int>
{

}
