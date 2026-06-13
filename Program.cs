
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using WebAPICRUD.Domain.Persistence;
using WebAPICRUD.Infrastructure;
using WebAPICRUD.Infrastructure.Endpoints;
using WebAPICRUD.Infrastructure.Interfaces;
using Serilog;

namespace WebAPICRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddLogging();

            // Register the country service for dependency injection
            builder.Services.AddTransient<ICountryService, CountryService>();

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();


            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
                app.UseHttpsRedirection();
            }

            

            app.UseAuthorization();

            app.MapGet("/", () => "Hello World!").Produces(200,typeof(string));
            app.MapCountryEndpoints();

            app.Run();
        }
    }
}
