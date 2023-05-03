
using Microsoft.EntityFrameworkCore;
using SoftwareCompany.APIs;
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

            //builder.Services.AddDbContext<SoftwareCompanyContext>(options =>
            //{
            //    string? LocalConnectionString = builder.Configuration.GetConnectionString("LocalConnectionString");
            //    options.UseSqlServer(LocalConnectionString);
            //});
            builder.Services.AddApplicationServices(builder.Configuration);

            #endregion

            #region Repos

            //builder.Services.AddScoped< IDepartmentRepo , DepartmentRepo >();
            //builder.Services.AddScoped< IGenericRepository<Developer> , GenericRepository<Developer> >();
            //builder.Services.AddScoped< IGenericRepository<Ticket> , GenericRepository<Ticket> >();
            builder.Services.AddRepoServices();
            #endregion

            #region Managers

            //builder.Services.AddScoped<IDepartmentManager,DepartmentManager>();
            //builder.Services.AddScoped<IDeveloperManager,DeveloperManager>();
            //builder.Services.AddScoped<ITicketManager,TicketManager>();
            builder.Services.AddManagerServices();

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