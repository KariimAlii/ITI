using Lab3.Models;
using Lab3.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Lab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(a =>
                {
                    a.LogoutPath = "/Account/Login";
                });

            builder.Services.AddTransient<IDepartment,DepartmentDB>();
            builder.Services.AddTransient<IStudent,StudentDB>();
            builder.Services.AddDbContext<ITIContext>(a =>
            {
                a.UseSqlServer(builder.Configuration.GetConnectionString("Connection1"));
            }, ServiceLifetime.Scoped);
            builder.Services.AddSession(a => { });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
//pattern: "{controller=Home}/{action=Index}/{id?}");
//pattern: "{controller}/{action}/{id?}");
//pattern: "{action=create}/{controller=student}/{id?}");
//pattern: "iti/{action=create}/{controller=student}/{id?}");
//pattern: "iti/{action=create}/{controller=student}");



//builder.Services.AddDbContext<ITIContext>(a =>
//{
//    a.UseSqlServer("Server=(localdb)\\ProjectModels;Database=ITIDB;Trusted_Connection=true;");
//    a.UseSqlServer(builder.Configuration.GetConnectionString("Connection1"));
//    a.UseLazyLoadingProxies();
//}, ServiceLifetime.Singleton);