using Company.Crm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Crm.Entityframework.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    // IsRequired
    // HasMaxLength
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // Tekil tablo adı buradan veya OnModelCreating içerisinde toplu yapılabilir
        //builder.ToTable("Customer");

        builder.Property(c => c.UserId).IsRequired();
        builder.Property(c => c.BirthDate).IsRequired();
        builder.Property(c => c.CompanyName)
            .IsRequired()
            .HasMaxLength(500);

        //builder.HasData(new List<Customer>()
        //{
        //    new() { Id = 1, UserId = 1, RegionId = 1, IdentityNumber = "1234", GenderId = 1, StatusTypeId = 1, BirthDate = new DateTime(1990,1,1), CompanyName = "Test 1", TitleId = 1 },
        //    new() { Id = 2, UserId = 2, RegionId = 1, IdentityNumber = "4567", GenderId = 1, StatusTypeId = 1, BirthDate = new DateTime(1990,1,1), CompanyName = "Test 2", TitleId = 1 }
        //});
    }
}