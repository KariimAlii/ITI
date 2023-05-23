using StudentApi.BLL;
using StudentApi.DAL;
using StudentApi.Entities;
using StudentApi.Payment;
using StudentApi.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;

namespace StudentApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = RegisterServices();
            config.DependencyResolver = new UnityResolver(container);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        private static IUnityContainer RegisterServices()
        {
            IUnityContainer container = new UnityContainer().AddExtension(new Diagnostic());

            container.RegisterType<StudentDBContext>();
            container.RegisterType<IStudentRepository, StudentRepository>();

            container.RegisterType<ICourseRepository, CourseRepository>();
            container.RegisterType<IPaymentService, CashService>();

            container.RegisterType<ICourseService, CourseService>();
            container.RegisterType<IStudentService, StudentService>();

            return container;
        }
    }
}
