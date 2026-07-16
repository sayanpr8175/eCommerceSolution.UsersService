using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add infrastructure services

builder.Services.AddInfrastructure();
builder.Services.AddCore();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

builder.Services.AddAutoMapper(typeof(RegisterRequestMappingProfile).Assembly);

// Fluent validations

builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

// Routing

app.UseRouting();

// Authentication

app.UseAuthentication();

// Authorization

app.UseAuthorization();

// Controllers routes

app.MapControllers();

app.Run();
