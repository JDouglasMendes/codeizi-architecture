using Codeizi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Codeizi.Service.API.Factory
{
    public class CodeiziContextFactory : IDesignTimeDbContextFactory<CodeiziContext>
    {
        public CodeiziContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CodeiziContext>();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                                            sqlServerOptionsAction:
                                            o => o.MigrationsAssembly("Codeizi.Infra.Data"));

            return new CodeiziContext(optionsBuilder.Options);
        }
    }
}