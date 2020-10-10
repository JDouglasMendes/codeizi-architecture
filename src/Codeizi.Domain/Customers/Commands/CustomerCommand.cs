using Codeizi.Infra.Core.Commands;
using System;

namespace Codeizi.Domain.Customers.Commands
{
    public abstract class CustomerCommand : Command
    {
        public string FirstName { get;  protected set; }
        public string LastName { get; protected set; }
        public string Number { get; protected set; }
        public DateTime CreationDate { get; protected set;  }
        public string City { get; protected set; }
        public string State { get; protected set; }
        public string PostalCode { get; protected set; }
        public string Street { get; protected set; }
    }
}