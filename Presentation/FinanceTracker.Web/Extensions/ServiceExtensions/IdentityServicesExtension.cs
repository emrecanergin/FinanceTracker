using FinanceTracker.Data.Context;
using FinanceTracker.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;

namespace FinanceTracker.Presentation.Extensions.ServiceExtensions
{
    public static class IdentityServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<FinanceTrackerDbContext>()
                .AddDefaultTokenProviders();


            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/Account/Login";
                options.SlidingExpiration = true;
            });
            
            return services;
        }
    }
}
