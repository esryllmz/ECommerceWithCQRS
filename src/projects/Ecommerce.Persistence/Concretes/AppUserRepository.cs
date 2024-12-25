using Core.Persistence.Repositories;
using Ecommerce.Application.Services.Repositories;
using Ecommerce.Domain.Entities;
using Ecommerce.Persistence.Contexts;

namespace Ecommerce.Persistence.Concretes;

public class AppUserRepository:EfRepositoryBase<AppUser,int,BaseDbContext>,IAppUserRepository
{
    public AppUserRepository(BaseDbContext context) : base(context)
    {
    }
}