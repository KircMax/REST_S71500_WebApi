using Microsoft.Extensions.DependencyInjection;
using S71500.RestApi.Application.Database;
using S71500.RestApi.Application.Repositories;
using S71500.RestApi.Application.Services;
using Siemens.Simatic.S7.Webserver.API.Services;

namespace S71500.RestApi.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IPlcConnectionFactory, PlcConnectionFactory>();
            services.AddSingleton<IApiServiceFactory, ApiStandardServiceFactory>();
            services.AddSingleton<IApiMethodService, ApiMethodService>();
            services.AddSingleton<IApiWebAppService, ApiWebAppService>();
            services.AddSingleton<IDocumentationDatabase, InMemoryDocumentationDatabase>();
            return services;
        }



        public static IServiceCollection AddDatabase(this IServiceCollection services,
       string connectionString)
        {
            services.AddSingleton<IDbConnectionFactory>(_ =>
                new NpgsqlConnectionFactory(connectionString));
            services.AddSingleton<DbInitializer>();
            return services;
        }
    }
}
