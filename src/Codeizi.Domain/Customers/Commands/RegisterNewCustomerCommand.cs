using System;

namespace Codeizi.Domain.Customers.Commands
{
    public class RegisterNewCustomerCommand : CustomerCommand
    {
        public RegisterNewCustomerCommand(
            string firstName,
            string lastName,
            string numberDocument,
            DateTime creationDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Number = numberDocument;
            CreationDate = creationDate;
        }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}