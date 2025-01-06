using Core.Security.JWT;
using Ecommerce.Domain.Entities;

namespace ECommerce.Application.Services.UserWithTokenServices;

public interface IUserWithTokenService
{
    public Task<AccessToken> CreateAccessTokenAsync(AppUser user);
    
}