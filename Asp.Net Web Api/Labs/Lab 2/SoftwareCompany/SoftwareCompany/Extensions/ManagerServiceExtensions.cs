using Microsoft.EntityFrameworkCore;
using SoftwareCompany.BL;
using SoftwareCompany.DAL;

namespace SoftwareCompany.APIs
{
    public static class ManagerServiceExtensions
    {
        public static IServiceCollection AddManagerServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentManager, DepartmentManager>();
            services.AddScoped<IDeveloperManager, DeveloperManager>();
            services.AddScoped<ITicketManager, TicketManager>();
            return services;
        }
    }
}

