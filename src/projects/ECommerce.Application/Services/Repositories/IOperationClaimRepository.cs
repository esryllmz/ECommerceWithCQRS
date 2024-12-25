﻿using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Ecommerce.Application.Services.Repositories;

public interface IOperationClaimRepository : IAsyncRepository<OperationClaim, int>
{
    
}