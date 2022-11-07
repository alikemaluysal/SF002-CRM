using Company.Crm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.Crm.Entityframework
{
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


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            // Program.cs içerisinde DbContext tanımı aşağıdaki gibi olursa;
            // builder.Services.AddDbContext<AppDbContext>()
            // Buradaki konfigrasyon çalışacaktır.
            if (!builder.IsConfigured)
            {
                var connectionString = "Server=(localdb)\\MsSqlLocalDb; Database=SF2_CRM; Trusted_Connection=True;";
                builder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
