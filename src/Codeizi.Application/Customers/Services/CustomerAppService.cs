using AutoMapper;
using Codeizi.Application.ComplexExample.Customers.Contracts;
using Codeizi.Application.ComplexExample.Customers.ViewModels;
using Codeizi.DI.Helper.Anotations;
using Codeizi.Domain.Customers.Commands;
using Codeizi.Infra.Core.MediatorBus;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace Codeizi.Application.ComplexExample.Customers.Services
{
    [Injectable(typeof(ICustomerAppService),
                typeof(CustomerAppService))]
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public CustomerAppService(IMapper mapper,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ValidationResult> AddOrUpdateAddress(
            CustomerAddressViewModel customerAddressViewModel)
            =>
            await _mediator.
                SendCommand(_mapper.Map<RegisterNewCustomerCommand>(customerAddressViewModel));

        public async Task<ValidationResult> Register(
            CustomerViewModel customerViewModel)
        {
            return await _mediator.
                SendCommand(_mapper.Map<RegisterNewCustomerCommand>(customerViewModel));
        }
    }
}