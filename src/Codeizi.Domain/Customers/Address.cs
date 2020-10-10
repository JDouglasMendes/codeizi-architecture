namespace Codeizi.Domain.ComplexExample.Customers
{
    public class Address
    {
        public string City { get; }
        public string State { get; }
        public string PostalCode { get; }
        public string Street { get; }

        public Address(
            string city,
            string state,
            string postalCode,
            string street)
        {
            City = city;
            State = state;
            PostalCode = postalCode;
            Street = street;
        }
    }
}