using Core.CrossCuttingConcerns.Serilog.Loggers;
using ECommerce.Application.Features.Categories.Rules;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Login;
using Core.Application.Pipelines.Performance;
using Core.Application.Pipelines.Validation;
using Core.Security.JWT;
using ECommerce.Application.Features.Auth.Rules;
using ECommerce.Application.Features.Products.Rules;
using ECommerce.Application.Services.RoleServices;
using Ecommerce.Application.Services.UserServices;
using ECommerce.Application.Services.UserServices;
using ECommerce.Application.Services.UserWithTokenServices;
using FluentValidation;
using MediatR;

namespace ECommerce.Application;

public static class AplicationServiceRegistration
{

    public static IServiceCollection AddApplicationServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<UserBusinessRules>();
        services.AddScoped<CategoryBusinessRules>();
        services.AddScoped<ProductBusinessRules>();

        services.AddTransient<LoggerServiceBase, MsSqlLogger>();
        
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserWithTokenService, UserWithTokenService>();
        services.AddScoped<IRoleService, RoleService>();
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
        
        services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(con =>
        {
            con.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            con.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            con.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            con.AddOpenBehavior(typeof(LoginBehavior<,>));
            con.AddOpenBehavior(typeof(LoggingBehavior<,>));

        });
          


        return services;
    }
}
