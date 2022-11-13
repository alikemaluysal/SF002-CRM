﻿using Company.Crm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Company.Crm.Domain.Entities.Task;

namespace Company.Crm.Entityframework;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    // SqlServer ve bağlantı metnini appsettings içerisiniden alarak Program.cs içerisinde konfigre ediyoruz.
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Email> Emails { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<StatusType> StatusTypes { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<OfferStatus> OfferStatuses { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Document> Documents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Program.cs içerisinde DbContext tanımı aşağıdaki gibi olursa;
        // builder.Services.AddDbContext<AppDbContext>()
        // Buradaki konfigrasyon çalışacaktır.
        if (!builder.IsConfigured)
        {
            var connectionString = "Server=(localdb)\\MsSqlLocalDb; Database=SF2_CRM_Dev; Trusted_Connection=True;";
            builder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Fluent API ile entity configuration
        //var customer = modelBuilder.Entity<Customer>();
        //customer.Property(c => c.UserId).IsRequired();
        //customer.Property(c => c.BirthDate).IsRequired();
        //customer.Property(c => c.CompanyName)
        //    .IsRequired()
        //    .HasMaxLength(500);

        // Tek tek configuration tanımlama
        //modelBuilder.ApplyConfiguration(new CustomerConfiguration());

        // Bir assembly içerisindeki tüm configuration sınıflarını otomatik tanımlama
        //modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        // Singular Table Names
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
        }

        // Seeders (HasData)
        //CustomerSeeder.Seed(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }
}