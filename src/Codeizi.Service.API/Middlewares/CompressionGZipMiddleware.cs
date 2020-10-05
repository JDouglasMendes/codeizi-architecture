using Microsoft.AspNetCore.Builder;

namespace Codeizi.Service.API.Middlewares
{
    public sealed class CompressionGZipMiddleware
    {
        public static void Configure(IApplicationBuilder app)
            => app.UseResponseCompression();
    }
}