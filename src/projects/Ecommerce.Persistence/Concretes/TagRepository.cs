using Core.Persistence.Repositories;
using Ecommerce.Application.Services.Repositories;
using Ecommerce.Domain.Entities;
using Ecommerce.Persistence.Contexts;

namespace Ecommerce.Persistence.Concretes;

public class TagRepository:EfRepositoryBase<Tag,Guid,BaseDbContext>,ITagRepository
{
    public TagRepository(BaseDbContext context) : base(context)
    {
    }
}