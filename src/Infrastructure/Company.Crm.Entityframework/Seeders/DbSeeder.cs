using Bogus;
using Bogus.DataSets;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Enums;
using Company.Framework.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Address = Bogus.DataSets.Address;

namespace Company.Crm.Entityframework.Seeders;

public static class DbSeeder
{
    public static void Seed(IServiceProvider serviceProvider)
    {
        var options = serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>();
        var context = new AppDbContext(options);

        SeedCustomers(context);
        SeedRoles(context);
        SeedUsers(context);
        SeedAddresses(context);
        //SeedNotifications(context);

        context.SaveChanges();
    }

    private static void SeedCustomers(AppDbContext context)
    {
        if (!context.Customers.Any())
        {
            var companySet = new Bogus.DataSets.Company("tr");

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
        }
    }

    private static void SeedRoles(AppDbContext context)
    {
        if (!context.Roles.Any())
            context.Roles.AddRange(new List<Role>
            {
                new() { Name = "Administrator" },
                new() { Name = "User" },
                new() { Name = "SalesManager" },
                new() { Name = "AccountManager" }
            });
    }

    private static void SeedUsers(AppDbContext context)
    {
        if (!context.Users.Any())
            context.Users.Add(new User
            {
                Username = "admin",
                Email = "admin@site.com",
                Password = SecurityHelper.HashCreate("admin"),
                Name = "admin",
                Surname = "admin",
                UserStatusId = (int)UserStatusEnum.Active
            });
    }

    private static void SeedAddresses(AppDbContext context)
    {
        if (!context.Addresses.Any())
        {
            var companySet = new Address("tr");

            var addressFaker = new Faker<Domain.Entities.Address>()
                .RuleFor(e => e.Description, c => companySet.City())
                .RuleFor(e => e.UserId, c => c.Random.Int(1, 100))
                .RuleFor(e => e.AddressType, c => (AddressTypeEnum)c.Random.Int(1, 2))
                .RuleFor(e => e.UserId, c => c.Random.Int(1, 10));

            var addresses = Enumerable.Range(1, 200)
                .Select(e => addressFaker.Generate())
                .ToList();

            context.Addresses.AddRange(addresses);
        }
    }

    private static void SeedNotifications(AppDbContext context)
    {
        if (!context.Notifications.Any())
        {
            var randomSet = new Lorem("tr");
            var notificationFaker = new Faker<Notification>();

            notificationFaker
                .RuleFor(x => x.IsRead, f => f.Random.Bool())
                .RuleFor(x => x.Title, f => randomSet.Slug())
                .RuleFor(x => x.Text, f => randomSet.Word());

            var notifications = Enumerable.Range(1, 10).Select(e => notificationFaker.Generate()).ToList();

            foreach (var notification in notifications)
            {
                var random = new Random().Next(1, 1000);
                notification.CreatedAt = DateTime.Now;
                notification.CreatedBy = random;
                notification.UserId = random;
            }

            context.Notifications.AddRange(notifications);
        }
    }
}