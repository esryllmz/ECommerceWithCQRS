using Ecommerce.Persistence;
using ECommerce.Application;
using Core.CrossCuttingConcerns;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.Security;
using Core.Security.Encryption;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServiceDependencies();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSecurityServices();

const string tokenOptionsConfigurationName="TokenOptions";
TokenOptions tokenOptions = builder.Configuration.GetSection(tokenOptionsConfigurationName).Get<TokenOptions>()
    ?? throw new InvalidOperationException($"TokenOptions not found: {tokenOptionsConfigurationName}");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidAudience = tokenOptions.Audience,
            ValidIssuer = tokenOptions.Issuer,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };

    }
        );
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.ConfigureCustomExceptionMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();//kimlik doğrulama
app.UseAuthorization();//yetkilendirme

app.MapControllers();

app.Run();
