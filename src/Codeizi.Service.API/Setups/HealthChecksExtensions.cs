using Codeizi.Service.API.Resources;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Codeizi.Service.API.Setups
{
    public static class HealthChecksExtensions
    {
        public static IServiceCollection AddHealthChecksProject(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString(Constants.ConnectionName));

            //services.AddHealthChecksUI();

            return services;
        }

        public static IApplicationBuilder UseHealthCheckUI(
            this IApplicationBuilder app)
        {
            /*
            app.UseEndpoints(config =>
            {
                config.MapHealthChecksUI();
            });
            */
            return app;
        }
    }
}