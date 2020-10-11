using Codeizi.Domain.Customers;
using System;
using System.Threading.Tasks;

namespace Codeizi.Domain.ComplexExample.Customers.Repository
{
    public interface ICustomerRepository
    {
        Task Register(Customer customer);

        Task Update(Customer customer);
    }
}