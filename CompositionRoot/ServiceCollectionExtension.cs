using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Persistence;
using Persistence.Repositories;
using Services;
using Services.Authentication;
using Services.Repositories;
using Services.Services.Abstraction;
using Services.Services.Implementation;
using AppContext = Persistence.AppContext;

namespace CompositionRoot
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            string connectionString =
                configuration.GetConnectionString("ConnectionString");

            services.AddDbContext<AppContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                }
            );

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            try
            {
                serviceProvider.GetService<AppContext>()?.Database.Migrate();
            }
            catch (Exception)
            {
                //migration unsuccessful, start application anyway in case production version was reverted
            }

            return services;
        }
    }
}
