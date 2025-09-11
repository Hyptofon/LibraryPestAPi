using Application.Books.Services;
using Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorService, AuthorService>();
        services.AddSingleton<IBookService, BookService>();
    }
}