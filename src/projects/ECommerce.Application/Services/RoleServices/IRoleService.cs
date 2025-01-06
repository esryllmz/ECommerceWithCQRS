using ECommerce.Application.Services.UserServices;
using Ecommerce.Domain.Entities;

namespace ECommerce.Application.Services.RoleServices;

public interface IRoleService
{
    Task AddRoleToUserAsync(AppUser user, string roleName);

}