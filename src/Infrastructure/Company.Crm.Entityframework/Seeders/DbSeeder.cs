using Bogus;
using Company.Crm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task = System.Threading.Tasks.Task;

namespace Company.Crm.Entityframework.Seeders
{
    public class DbSeeder
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>();
            var context = new AppDbContext(options);

            SeedCustomers(context);

            await context.SaveChangesAsync();
        }

        private static void SeedCustomers(AppDbContext context)
        {
            if (!context.Customers.Any())
            {
                var companySet = new Bogus.DataSets.Company(locale: "tr");

                // Bogus ile Seed data oluşturma
                var customerFaker = new Faker<Customer>()
                    .RuleFor(e => e.CompanyName, c => companySet.CompanyName())
                    .RuleFor(e => e.IdentityNumber, c => c.Random.AlphaNumeric(11))
                    .RuleFor(e => e.BirthDate, c =>
                        c.Date.Between(new DateTime(1960, 1, 1), DateTime.Now))
                    .RuleFor(e => e.UserId, c => c.Random.Int(1, 10));

                var customers = Enumerable.Range(1, 200)
                    .Select(e => customerFaker.Generate())
                    .ToList();

                context.Customers.AddRange(customers);

                //context.Customers.AddRange(new List<Customer>()
                //{
                //    new() { UserId = 1, RegionId = 1, IdentityNumber = "1234", GenderId = 1, StatusTypeId = 1, BirthDate = new DateTime(1990,1,1), CompanyName = "Test 1", TitleId = 1 },
                //    new() { UserId = 2, RegionId = 1, IdentityNumber = "4567", GenderId = 1, StatusTypeId = 1, BirthDate = new DateTime(1990,1,1), CompanyName = "Test 2", TitleId = 1 }
                //});
            }
        }
    }
}
