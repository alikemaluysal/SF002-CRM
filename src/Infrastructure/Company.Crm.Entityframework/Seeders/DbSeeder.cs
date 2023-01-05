using Bogus;
using Bogus.DataSets;
using Company.Crm.Domain.Entities;
using Company.Crm.Domain.Entities.Lst;
using Company.Crm.Domain.Entities.Usr;
using Company.Crm.Domain.Enums;
using Company.Framework.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
        SeedNotifications(context);
        SeedSales(context);
        SeedLstTables(context);

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
                .RuleFor(e => e.UserId, c => c.Random.Int(1, 10))
                .RuleFor(e => e.StatusTypeId, c => c.Random.Int(1, 2));

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
        if (!context.UserAddresses.Any())
        {
            var companySet = new Address("tr");

            var addressFaker = new Faker<UserAddress>()
                .RuleFor(e => e.Description, c => companySet.City())
                .RuleFor(e => e.UserId, c => c.Random.Int(1, 100))
                .RuleFor(e => e.AddressType, c => (AddressTypeEnum)c.Random.Int(1, 2))
                .RuleFor(e => e.UserId, c => c.Random.Int(1, 10));

            var addresses = Enumerable.Range(1, 200)
                .Select(e => addressFaker.Generate())
                .ToList();

            context.UserAddresses.AddRange(addresses);
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
                .RuleFor(x => x.Description, f => randomSet.Word());

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

    private static void SeedSales(AppDbContext context)
    {
        if (!context.Sales.Any())
        {
            var randomSet = new Lorem("tr");
            var saleFaker = new Faker<Sale>();

            saleFaker
                .RuleFor(x => x.EmployeeUserId, f => f.Random.Int(1, 100))
                .RuleFor(x => x.RequestId, f => f.Random.Int(1, 100))
                .RuleFor(x => x.SaleAmount, f => f.Random.Int(1, 10000))
                .RuleFor(x => x.Description, f => randomSet.Word())
                .RuleFor(x => x.SaleDate, f => f.Date.Past());


            var sales = Enumerable.Range(1, 10).Select(e => saleFaker.Generate()).ToList();

            context.Sales.AddRange(sales);
        }
    }


    private static void SeedLstTables(AppDbContext context)
    {
        if (!context.Departments.Any())
        {
            context.Departments.AddRange(new List<Department>
            {
                new() { Name = "Administration" },
                new() { Name = "Sale" },
                new() { Name = "Marketing" },
                new() { Name = "Accounting" },
                new() { Name = "Technical" }
            });
        }

        if (!context.Genders.Any())
        {
            context.Genders.AddRange(new List<Gender>
            {
                new() { Name = "Male" },
                new() { Name = "Female" }
            });
        }

        if (!context.OfferStatuses.Any())
        {
            context.OfferStatuses.AddRange(new List<OfferStatus>
            {
                new() { Name = "Active" },
                new() { Name = "In Progress" },
                new() { Name = "Closed" }
            });
        }

        if (!context.Regions.Any())
        {
            context.Regions.AddRange(new List<Region>
            {
                new() { Name = "Istanbul-Avrupa" },
                new() { Name = "Istanbul-Anadolu" },
                new() { Name = "Ankara" }
            });
        }

        if (!context.StatusTypes.Any())
        {
            context.StatusTypes.AddRange(new List<StatusType>
            {
                new() { Name = "Active" },
                new() { Name = "Archive" },
                new() { Name = "Black Listed" }
            });
        }

        if (!context.UserStatuses.Any())
        {
            context.UserStatuses.AddRange(new List<UserStatus>
            {
                new() { Name = "Active" },
                new() { Name = "Not Activated" },
                new() { Name = "Passive" }
            });
        }

        if (!context.Titles.Any())
        {
            context.Titles.AddRange(new List<Title>
            {
                new() { Name = "Software Developer" },
                new() { Name = "Engineer" }
            });
        }
    }
}