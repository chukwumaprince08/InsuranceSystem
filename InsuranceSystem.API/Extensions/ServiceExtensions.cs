using System;
using InsuranceSystem.Application.Interface;
using InsuranceSystem.Application.Services;
using InsuranceSystem.Common.Dates;
using InsuranceSystem.Core.Interface;
using InsuranceSystem.Infrastructure.DBContext;
using InsuranceSystem.Infrastructure.Manager;
using InsuranceSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InsuranceSystem.API.Extensions
{
	public static class ServiceExtensions
	{
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                 b => b
                .MigrationsAssembly("InsuranceSystem.API")));
        }

        public static void ConfigureCors(this IServiceCollection services) =>
          services.AddCors(options =>
          {
              options.AddPolicy("CorsPolicy", builder =>
              builder.WithOrigins("")
              .AllowAnyHeader()
              .WithMethods("POST", "GET", "PUT", "DELETE")
              .AllowCredentials()
              .Build());
          });

        public static void ConfigureExtensionServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IPolicyHolderRepository, PolicyHolderRepository>();
            services.AddScoped<IPolicyService, PolicyService>();
            services.AddScoped<IDateService, DateService>();
            services.AddScoped<IClaimsRepository, ClaimsRepository>();
        }
    }
}

