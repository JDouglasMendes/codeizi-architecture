using Codeizi.Infra.Data.Context;
using Codeizi.Service.API.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Codeizi.Service.API.Setups
{
    public static class DbContextExtensions
    {
        public static readonly ILoggerFactory factory
        = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public static IServiceCollection AddDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            if (!string.IsNullOrEmpty(configuration.GetConnectionString(Constants.ConnectionName)))
            {
                services.AddDbContext<CodeiziContext>(options =>
                    options.UseLoggerFactory(factory).
                    UseSqlServer(configuration.GetConnectionString(Constants.ConnectionName),
                    x => x.MigrationsAssembly("Codeizi.Infra.Data")));
            }
            else
            {
                _ = services.AddDbContext<CodeiziContext>(options =>
                         options.UseInMemoryDatabase(databaseName: "InMemoryDatabase"));
            }

            return services;
        }
    }
}