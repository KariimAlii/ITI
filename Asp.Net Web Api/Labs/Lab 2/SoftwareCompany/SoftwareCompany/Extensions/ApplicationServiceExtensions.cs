using Microsoft.EntityFrameworkCore;
using SoftwareCompany.DAL;
using System.Collections.Generic;
using SoftwareCompany.BL;


namespace SoftwareCompany.APIs
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, ConfigurationManager config)
        {
            //services.BuildServiceProvider().GetService<IConfiguration>().GetConnectionString()
            services.AddDbContext<SoftwareCompanyContext>(options =>
            {
                string? LocalConnectionString = config.GetConnectionString("LocalConnectionString");
                options.UseSqlServer(LocalConnectionString);
            });
            return services;
        }
    }
}
