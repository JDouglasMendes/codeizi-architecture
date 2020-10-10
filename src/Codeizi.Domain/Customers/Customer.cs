using Codeizi.Domain.ComplexExample.Customers;
using Codeizi.Infra.Core.Entities;
using System;

namespace Codeizi.Domain.Customers
{
    public class Customer : Entity<Guid>
    {
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }

        public Customer(
            Name name,
            Document document)
        {
            Name = name;
            Document = document;
        }

        public void AddAddress(Address address)
        {
            Address = address;
        }
    }
}