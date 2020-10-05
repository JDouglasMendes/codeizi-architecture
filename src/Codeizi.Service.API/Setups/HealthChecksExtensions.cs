using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Codeizi.Service.API.Setups
{
    public static class HealthChecksExtensions
    {
        public static IServiceCollection AddHealthChecksProject(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddHealthChecks()
                .AddSqlServer(connectionString);

            services.AddHealthChecksUI();

            return services;
        }

        public static IApplicationBuilder UseHealthCheckUI(
            this IApplicationBuilder app)
        {
            app.UseEndpoints(config =>
            {
                config.MapHealthChecksUI();
            });
            return app;
        }
    }
}