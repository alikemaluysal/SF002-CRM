using Company.Crm.Application;
using Company.Crm.Entityframework;
using Company.Framework.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Company CRM API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddEntityFrameworkRegistration(builder.Configuration);
builder.Services.AddApplicationRegistration(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsAyari", policy =>
    {
        policy
            .WithOrigins(builder.Configuration["App:ClientUrls"].Split(','))
            .AllowAnyHeader().AllowAnyMethod().AllowCredentials();

        // Tüm adreslere izin verme
        //policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // Yetkilendirmeyi yapan
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Auth:Jwt:Issuer"],

            // Yetkilendirmeyi kullanan client
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Auth:Jwt:Audience"],

            // Token zaman doðrulamasý
            ValidateLifetime = true,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Auth:Jwt:SecurityKey"]))
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var isProduction = app.Environment.IsProduction();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var errorMessage = "Error!";

        var error = context.Features.Get<IExceptionHandlerPathFeature>();

        var exception = error?.Error;

        if (exception is FileNotFoundException)
        {
            errorMessage = "File Not Found!";
        }
        else if (exception is UnauthorizedAccessException)
        {
            //context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            errorMessage = "Unauthorized Access to resource!";
        }
        else if (exception is ValidationException)
        {
            context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
            errorMessage = "Validation error!";
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            errorMessage = "Internal error!";
        }

        if (!isProduction) errorMessage = exception.Message;

        var errorResponse = new ServiceResponse<string>(errorMessage);
        var errorBody = JsonSerializer.Serialize(errorResponse);

        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(errorBody);
    });
});

app.UseHttpsRedirection();

app.UseCors("CorsAyari");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();