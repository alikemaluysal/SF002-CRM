using Company.Crm.Application;
using Company.Crm.Entityframework;
using Company.Crm.Web.Api;
using Company.Crm.Web.Api.Middlewares;
using Microsoft.OpenApi.Models;

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

        //// T�m adreslere izin verme
        //policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
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

            // Token zaman do�rulamas�
            ValidateLifetime = true,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Auth:Jwt:SecurityKey"]))
        };
    });


builder.Services.AddApiRegistration(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(errorApp => errorApp.UseGlobalExceptionHandling(app.Environment.IsProduction()));
app.UseHttpsRedirection();
app.UseCors("CrmCors");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();