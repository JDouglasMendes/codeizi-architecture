using Codeizi.Domain.Customers;
using System;

namespace Codeizi.Infra.Data.DAO.Customers
{
    public interface ICustomerDAO : IGenericDAO<Customer, Guid>
    {
    }
}