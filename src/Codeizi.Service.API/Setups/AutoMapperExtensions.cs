using AutoMapper;
using Codeizi.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Codeizi.Service.API.Setups
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
            =>
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile),
                                    typeof(ViewModelToDomainMappingProfile));
    }
}