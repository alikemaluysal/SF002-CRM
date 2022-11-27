using Microsoft.AspNetCore.Authentication.Cookies;

namespace Company.Crm.Web.Mvc;

public static class ServiceRegistrations
{
    public static void AddMvcRegistration(this IServiceCollection services)
    {
        services
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
                options.LogoutPath = "/Auth/Logout";
                options.AccessDeniedPath = "/Auth/AccessDenied";
            });
    }
}