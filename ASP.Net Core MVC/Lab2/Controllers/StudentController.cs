using Microsoft.AspNetCore.Mvc;
using Lab2.Models;
namespace Lab2.Controllers
{
    public class StudentController : Controller
    {
        
        public ViewResult Index()
        {
            List<Student> students = new List<Student>
            {
                new Student() {ID =  1, Name = "Karim Ali",Grade = 89},
                new Student() {ID =  2, Name = "Mohamed Mostafa",Grade = 93},
                new Student() {ID =  3, Name = "Ahmed Hassanin",Grade = 87},
                new Student() {ID =  3, Name = "Mohamed Ahmed",Grade = 95}

            };
            return View(students);
        }
    }
}
