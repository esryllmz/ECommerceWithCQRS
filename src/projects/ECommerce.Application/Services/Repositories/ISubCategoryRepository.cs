using Core.Persistence.Repositories;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services.Repositories;

public interface ISubCategoryRepository: IAsyncRepository<SubCategory,int>
{
    
}