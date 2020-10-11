using Codeizi.DI.Helper.Anotations;
using Codeizi.Domain.Customers;
using Codeizi.Infra.Data.Context;
using System;

namespace Codeizi.Infra.Data.DAO.Customers
{
    [Injectable(typeof(ICustomerDAO),
                typeof(CustomerDAO))]
    public class CustomerDAO : GenericDAO<Customer, Guid>, ICustomerDAO
    {
        public CustomerDAO(CodeiziContext context)
            : base(context)
        {
        }
    }
}