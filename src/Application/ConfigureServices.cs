using System.Reflection;
using Application.Common.Behaviours;
using Application.Common.Interfaces;
using Application.Books.Services; 
using Application.Authors.Services; 
using FluentValidation; 
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddSingleton<IBookService, BookService>();
        services.AddSingleton<IAuthorService, AuthorService>();
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    }
}