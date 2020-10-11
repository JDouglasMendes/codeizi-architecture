using Codeizi.DI.Helper.Anotations;
using Codeizi.Domain.ComplexExample.Customers.Repository;
using Codeizi.Domain.Customers;
using Codeizi.Infra.Data.DAO.Customers;
using System.Threading.Tasks;

namespace Codeizi.Infra.Data.Repository
{
    [Injectable(typeof(ICustomerRepository),
                typeof(CustomerRepository))]
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ICustomerDAO customerDAO;

        public CustomerRepository(ICustomerDAO customerDAO)
        {
            this.customerDAO = customerDAO;
        }

        public async Task Register(Customer customer)
            => await customerDAO.AddAsync(customer);

        public async Task Update(Customer customer)
            => await customerDAO.Update(customer);
    }
}