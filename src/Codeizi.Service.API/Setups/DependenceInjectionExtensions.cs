using Codeizi.DI.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Codeizi.Service.API.Setups
{
    public static class DependenceInjectionExtensions
    {
        public static IServiceCollection AddCodeiziDI(this IServiceCollection services)
            => services.AddInjectables(typeof(Startup));
    }
}