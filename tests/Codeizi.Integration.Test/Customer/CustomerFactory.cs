using Codeizi.Application.ComplexExample.Customers.ViewModels;
using System;

namespace Codeizi.Integration.Test.Customer
{
    public static class CustomerFactory
    {
        public static CustomerViewModel Create()
            => new CustomerViewModel
            {
                CreationDate = new DateTime(2020, 1, 1),
                FirstName = "Integration",
                LastName = "Test",
                Number = "123456789"
            };
    }
}