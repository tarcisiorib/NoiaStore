using Clients.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clients.API.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Line1)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(a => a.Line2)
                .HasColumnType("varchar(200)");

            builder.Property(a => a.City)
                .IsRequired()
                .HasColumnType("varchar(100)");
            
            builder.Property(a => a.State)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.ZipCode)
                .IsRequired()
                .HasColumnType("varchar(20)");
            
            builder.Property(a => a.Country)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Adresses");

        }
    }
}
