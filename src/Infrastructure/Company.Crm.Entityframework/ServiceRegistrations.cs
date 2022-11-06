using Company.Crm.Domain.Repositories;
using Company.Crm.Entityframework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Crm.Entityframework
{
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


            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IRequestRepository, RequestRepository>();
        }
    }
}
