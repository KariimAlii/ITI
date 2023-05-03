using SoftwareCompany.BL;
using SoftwareCompany.DAL;
namespace SoftwareCompany.APIs
{
    public static class RepoServiceExtensions
    {
        public static IServiceCollection AddRepoServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            services.AddScoped<IGenericRepository<Developer>, GenericRepository<Developer>>();
            services.AddScoped<IGenericRepository<Ticket>, GenericRepository<Ticket>>();
            return services;
        }
    }
}