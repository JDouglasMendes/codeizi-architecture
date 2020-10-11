namespace Codeizi.Domain.ComplexExample.Customers
{
    public class Name
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        protected Name() { }

        public Name(
            string firstName,
            string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}