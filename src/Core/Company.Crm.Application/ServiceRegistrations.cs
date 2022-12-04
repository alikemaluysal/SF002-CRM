using System.Reflection;
using Company.Crm.Application.Services;
using Company.Crm.Application.Services.Abstracts;
using Company.Crm.Application.UserEmail;
using Company.Framework.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        services.AddTransient<IPersonEmailService, PersonEmailService>();
        services.AddTransient<IPhoneService, PhoneService>();
        services.AddTransient<ITitleService, TitleService>();
        services.AddTransient<IDocumentService, DocumentService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IUserStatusService, UserStatusService>();

        services.Configure<EmailSettings>(configuration.GetSection("Email"));
        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<IUserEmailService, UserEmailService>();
    }
}
