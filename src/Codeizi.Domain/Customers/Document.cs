using System;

namespace Codeizi.Domain.ComplexExample.Customers
{
    public sealed class Document
    {
        public string Number { get; private set; }
        public DateTime CreationDate { get; private set; }

        public Document(
            string number,
            DateTime creationDate)
        {
            Number = number;
            CreationDate = creationDate;
        }
    }
}