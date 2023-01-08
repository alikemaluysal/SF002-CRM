using Company.Crm.Application;
using Company.Crm.Entityframework;
using Company.Framework.Dtos;
using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();

app.MapControllers();

app.Run();