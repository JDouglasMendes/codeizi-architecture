using Codeizi.Application.AutoMapper;
using Codeizi.DI.AspNetCore;
using Codeizi.Domain.Customers.CommandHandlers;
using Codeizi.Infra.Bus;
using Codeizi.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Codeizi.Service.API.Setups
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCodeiziDI(this IServiceCollection services)
            => services.AddInjectables(typeof(Startup))
                       .AddInjectables(typeof(DomainToViewModelMappingProfile))
                       .AddInjectables(typeof(InMemoryBus))
                       .AddInjectables(typeof(CodeiziContext))
                       .AddInjectables(typeof(RegisterNewCustomerCommandHandler))   ;
    }
}