namespace Codeizi.Domain.ComplexExample.Customers
{
    public sealed class Name
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Name(
            string firstName,
            string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}