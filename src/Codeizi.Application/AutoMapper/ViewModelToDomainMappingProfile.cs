using AutoMapper;
using Codeizi.Application.ComplexExample.Customers.ViewModels;
using Codeizi.Domain.Customers.Commands;

namespace Codeizi.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, RegisterNewCustomerCommand>()
                .ConvertUsing(x => new RegisterNewCustomerCommand(
                                                                x.FirstName,
                                                                x.LastName,
                                                                x.Number,
                                                                x.CreationDate));
        }
    }
}