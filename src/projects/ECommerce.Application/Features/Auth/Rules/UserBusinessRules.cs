using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using ECommerce.Application.Features.Auth.Constants;
using Ecommerce.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ECommerce.Application.Features.Auth.Rules;

public sealed class UserBusinessRules(IAppUserRepository _userRepository)
{
    
    public async Task UserEmailShouldNotExistsWhenInserted(string email)
    {
        bool userExists=await _userRepository.AnyAsync(x=>x.Email == email);
        if (userExists)
        {
            throw new AuthorizationException(AuthMessages.UserMailAllreadyExists);
        }
    }

    public async Task UserEmailShouldNotExistsWhenUpdated(int id, string email)
    {
        bool userExists=await _userRepository.AnyAsync(x=> x.Id != id  && x.Email == email ) ;
        if (userExists)
        {
            throw new AuthorizationException(AuthMessages.UserMailAllreadyExists);
        }
    }
    
}