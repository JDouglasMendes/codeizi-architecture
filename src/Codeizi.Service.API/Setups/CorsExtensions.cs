using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Codeizi.Service.API.Setups
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCorsService(
            this IServiceCollection services,
            string policy)
            => services.AddCors((options) =>
            {
                options.AddPolicy(policy,
                    builder=>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

        public static IApplicationBuilder UseCorsApp(
            this IApplicationBuilder app,
            string policy)
        {
            app.UseCors(policy);
            return app;
        }

    }
}