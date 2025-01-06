using Core.Security.Entities;
using Core.Security.JWT;
using Ecommerce.Application.Services.Repositories;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Services.UserWithTokenServices;

public sealed class UserWithTokenService : IUserWithTokenService
{
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;

    public UserWithTokenService(ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository)
    {
        _tokenHelper = tokenHelper;
        _userOperationClaimRepository = userOperationClaimRepository;
    }
    
    public async Task<AccessToken> CreateAccessTokenAsync(AppUser user)
    {
        List<OperationClaim> claims=
            await  _userOperationClaimRepository
                .Query()
                .AsNoTracking()
                .Where(p=>p.UserId == user.Id)
                .Select(o=>new OperationClaim{Id = o.OperationClaimId, Name = o.OperationClaim.Name})
                .ToListAsync();
        AccessToken token = _tokenHelper.CreateToken(user, claims);
        return token;
    }
}