using Core.Persistence.Repositories;
using Core.Security.Entities;
using Ecommerce.Application.Services.Repositories;
using Ecommerce.Persistence.Contexts;

namespace Ecommerce.Persistence.Concretes;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, int, BaseDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext context) : base(context)
    {
    }
}