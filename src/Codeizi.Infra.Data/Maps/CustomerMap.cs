using Codeizi.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace Codeizi.Infra.Data.Maps
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Id)
              .HasColumnName("Id");

            builder.OwnsOne(x => x.Name, name =>
            {
                name.Property(n => n.FirstName)
                        .HasColumnName("FirstName")
                        .HasMaxLength(100)
                        .IsRequired();

                name.Property(s => s.LastName)
                        .HasColumnName("LastName")
                        .HasMaxLength(100)
                        .IsRequired();
            });

            builder.OwnsOne(x => x.Document, document =>
            {
                document.Property(n => n.Number)
                    .HasColumnName("Number")
                    .HasMaxLength(30)
                    .IsRequired();

                document.Property(s => s.CreationDate)
                        .HasColumnName("CreationDate")
                        .IsRequired();

                document
                    .HasIndex(x => new { x.Number, x.CreationDate });
            });

            builder.OwnsOne(x => x.Address, address =>
            {
                address.Property(n => n.City)
                        .HasColumnName("City")
                        .HasMaxLength(50);

                address.Property(n => n.PostalCode)
                        .HasColumnName("PostalCode")
                        .HasMaxLength(10);

                address.Property(n => n.State)
                        .HasColumnName("State")
                        .HasMaxLength(50);

                address.Property(n => n.Street)
                        .HasColumnName("Street")
                        .HasMaxLength(200);
            });
        }
    }
}