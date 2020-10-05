using Codeizi.Service.API.Setups;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Codeizi.Service.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
            => Configuration = configuration;

        public static void ConfigureServices(IServiceCollection services)
        {
            services.
                AddControllerAndJsonOptions()
                .AddSwagger()
                .AddCorsService("CodeiziCors"); // change your cors

                // .AddHealthChecksProject("");
        }

        public static void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerApp();

            app.UseCorsApp("CodeiziCors");

            app.UseRouting();

            app.UseHealthCheckUI();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}