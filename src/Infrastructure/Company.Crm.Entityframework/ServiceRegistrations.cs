using Company.Crm.Domain.Repositories;
using Company.Crm.Entityframework.Repositories;
using Company.Crm.Entityframework.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Crm.Entityframework;

public static class ServiceRegistrations
{
    public static void AddEntityFrameworkRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString)
        );

        // Konfigrasyonu DbContext OnConfiguring içerisinde yapılabilir
        //services.AddDbContext<AppDbContext>();

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IRequestRepository, RequestRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IEmailRepository, EmailRepository>();
        services.AddScoped<IOfferRepository, OfferRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IRegionRepository, RegionRepository>();
        services.AddScoped<IStatusTypeRepository, StatusTypeRepository>();
        services.AddScoped<IOfferStatusRepository, OfferStatusRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IPhoneRepository, PhoneRepository>();
        services.AddScoped<ITitleRepository, TitleRepository>();
        services.AddScoped<IDocumentRepository, DocumentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        DbSeeder.Seed(services.BuildServiceProvider()).GetAwaiter().GetResult();
    }
}