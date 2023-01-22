using Company.Crm.Web.Api.Jobs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Company.Crm.Web.Api;

public static class ServiceRegistrations
{
    public static void AddApiRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: "CrmCors", policy =>
            {
                policy
                    .WithOrigins(configuration["App:ClientUrls"].Split(','))
                    .AllowAnyHeader().AllowAnyMethod().AllowCredentials();

                // Tüm adreslere izin verme
                //policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });
        });

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // Yetkilendirmeyi yapan
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Auth:Jwt:Issuer"],

                    // Yetkilendirmeyi kullanan client
                    ValidateAudience = true,
                    ValidAudience = configuration["Auth:Jwt:Audience"],

                    // Token zaman doğrulaması
                    ValidateLifetime = true,
                    //ClockSkew = TimeSpan.FromMinutes(1),
                    ClockSkew = TimeSpan.Zero,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Auth:Jwt:SecurityKey"]))
                };
            });


        // Background Task
        services.AddHostedService<TimedHostedService>();
        services.AddHostedService<WeeklyEmailHostedService>();
    }
}