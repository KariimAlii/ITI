using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageApp.Models;
using RazorPageApp.Services;
using System.Reflection.Metadata;

namespace RazorPageApp.Pages.Students
{
    public class IndexModel : PageModel
    {
        IStudent db;
        public  List<Student> Students { get; set; }
        public IndexModel(IStudent _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            Students = db.GetAll();
        }
    }
}
