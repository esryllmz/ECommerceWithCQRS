using Core.Persistence.Repositories;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services.Repositories;

public interface ITagRepository: IAsyncRepository<Tag,Guid>
{
    
}