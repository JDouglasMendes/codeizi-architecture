using Codeizi.Domain.ComplexExample.Customers;
using Codeizi.Domain.Customers.Commands;
using System;

namespace Codeizi.Domain.Customers
{
    public static class CustomerFactory
    {
        public static Customer New(string firstName,
                                   string lastName,
                                   string numberDocument,
                                   DateTime creationDate)
        => new Customer(new Name(firstName,
                                lastName),
                        new Document(numberDocument,
                                     creationDate));

        public static Customer New(RegisterNewCustomerCommand command)
            => New(command.FirstName,
                command.LastName,
                command.Number,
                command.CreationDate);
    }
}