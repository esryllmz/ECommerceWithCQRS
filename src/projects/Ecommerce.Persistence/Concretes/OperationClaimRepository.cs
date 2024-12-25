using Core.Persistence.Repositories;
using Core.Security.Entities;
using Ecommerce.Application.Services.Repositories;
using Ecommerce.Persistence.Contexts;

namespace Ecommerce.Persistence.Concretes;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, BaseDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}