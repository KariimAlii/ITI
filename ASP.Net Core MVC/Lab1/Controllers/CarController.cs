using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class CarController : Controller
    {
        public string Display()
        {
            return "Hello from Asp.net Core Karim!";
        }
        public int Add(int id)
        {
            return id + 4;
        }
        public ViewResult Show()
        {
            return View();
        }
        public ViewResult showDictionary()
        {
            return View("Dictionary");
        }
        public ViewResult showIndex()
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
