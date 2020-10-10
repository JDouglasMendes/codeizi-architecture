using Codeizi.Application.ComplexExample.Customers.ViewModels;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Codeizi.Application.ComplexExample.Customers.Contracts
{
    public interface ICustomerAppService
    {
        Task<ValidationResult> Register(CustomerViewModel customerViewModel);

        Task<ValidationResult> AddOrUpdateAddress(CustomerAddressViewModel customerAddressViewModel);
    }
}