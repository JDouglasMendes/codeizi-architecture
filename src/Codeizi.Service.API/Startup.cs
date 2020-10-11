using Codeizi.Service.API.Resources;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllerAndJsonOptions()
                .AddMediator()
                .AddCodeiziDI()
                .AddSwagger()
                .AddCorsService(Constants.CorsName) // change your cors
                .AddDbContext(Configuration)
                .AddHealthChecksProject(Configuration)
                .AddAutoMapper();
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

            app.UseCorsApp(Constants.CorsName);

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