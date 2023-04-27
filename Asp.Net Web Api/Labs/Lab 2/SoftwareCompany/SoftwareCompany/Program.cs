
using Microsoft.EntityFrameworkCore;
using SoftwareCompany.BL;
using SoftwareCompany.DAL;

namespace SoftwareCompany
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Default Services
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region Context

            builder.Services.AddDbContext<SoftwareCompanyContext>(options =>
            {
                string? LocalConnectionString = builder.Configuration.GetConnectionString("LocalConnectionString");
                options.UseSqlServer(LocalConnectionString);
            });
            #endregion

            #region Repos

            builder.Services.AddScoped< IGenericRepository<Department> , GenericRepository<Department> >();
            builder.Services.AddScoped< IGenericRepository<Developer> , GenericRepository<Developer> >();
            builder.Services.AddScoped< IGenericRepository<Ticket> , GenericRepository<Ticket> >();

            #endregion

            #region Managers

            builder.Services.AddScoped<IDepartmentManager,DepartmentManager>();
            builder.Services.AddScoped<IDeveloperManager,DeveloperManager>();
            builder.Services.AddScoped<ITicketManager,TicketManager>();

            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}