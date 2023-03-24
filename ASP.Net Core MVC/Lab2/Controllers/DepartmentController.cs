using Lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class DepartmentController : Controller
    {
        public ViewResult Index()
        {
            ViewData["departments"] = new List<Department>
            {
                new Department{Id = 1 , Name = "PWD" , ManagerName = "Ashraf Hakimi"},
                new Department{Id = 2 , Name = "Open Source" , ManagerName = "Ahmed Metwally"},
                new Department{Id = 3 , Name = "Cyber Security" , ManagerName = "Moataz Rashed"}
            };
            ViewBag.Title = "Departments Table";
            return View();
        }
    }
}
