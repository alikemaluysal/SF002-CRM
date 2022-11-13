using System.Reflection;
using Company.Crm.Application.Services;
using Company.Crm.Application.Services.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Company.Crm.Application;

public static class ServiceRegistrations
{
    public static void AddApplicationRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        // Tek bir MappingProfile'ı ayarla
        //services.AddAutoMapper(typeof(MappingProfile));

        // Crm.Application altında gördüğün tüm Profile sınıflarını otomatik ayarlar.
        var assembly = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assembly);

        services.AddTransient<ICustomerService, CustomerService>();
        services.AddTransient<IEmployeeService, EmployeeService>();
        services.AddTransient<INotificationService, NotificationService>();
        services.AddTransient<IAddressService, AddressService>();
        services.AddTransient<IRegionService, RegionService>();
        services.AddTransient<IOfferService, OfferService>();
        services.AddTransient<ITaskService, TaskService>();
        services.AddTransient<IStatusTypeService, StatusTypeService>(); 
        services.AddTransient<IOfferStatusService, OfferStatusService>();
        services.AddTransient<IDepartmentService, DepartmentService>();
        services.AddTransient<IRequestService, RequestService>();
    }
}