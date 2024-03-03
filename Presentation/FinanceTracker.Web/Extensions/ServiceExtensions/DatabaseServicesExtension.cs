using FinanceTracker.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Presentation.Extensions.ServiceExtensions
{
    public static class DatabaseServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services,WebApplicationBuilder builder)
        {
            services.AddDbContext<FinanceTrackerDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
            });
            return services;
        }
    }
}
