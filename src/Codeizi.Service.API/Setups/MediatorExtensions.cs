using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Codeizi.Service.API.Setups
{
    public static class MediatorExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
            => services.AddMediatR(typeof(Startup));
    }
}