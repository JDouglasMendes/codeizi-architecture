using Codeizi.Domain.ComplexExample.Customers.Repository;
using Codeizi.Domain.Customers.Commands;
using Codeizi.Infra.Core.Commands;
using Codeizi.Infra.Core.MediatorBus;
using Codeizi.Infra.Core.UOW;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Codeizi.Domain.Customers.CommandHandlers
{
    public class RegisterNewCustomerCommandHandler
        : CommandHandler,
         IRequestHandler<RegisterNewCustomerCommand, ValidationResult>
    {
        private readonly ICustomerRepository _customer;

        public RegisterNewCustomerCommandHandler(
            IUnitOfWork uow,
            IMediatorHandler bus,
            ICustomerRepository customer)
            : base(uow,
                  bus)
        {
            _customer = customer;
        }

        public async Task<ValidationResult> Handle(
            RegisterNewCustomerCommand request,
            CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var customer = CustomerFactory.New(request);

            await _customer.AddCustomer(customer);

            return await CommitAsync();
        }
    }
}