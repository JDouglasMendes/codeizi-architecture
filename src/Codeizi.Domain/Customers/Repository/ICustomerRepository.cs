using Codeizi.Domain.Customers;
using System;
using System.Threading.Tasks;

namespace Codeizi.Domain.ComplexExample.Customers.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> AddCustomer(Customer customer);

        Task<Customer> AddOrUpdateAdress(Guid id, Address address);
    }
}