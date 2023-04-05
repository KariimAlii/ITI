using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageApp.Models;
using RazorPageApp.Services;

namespace RazorPageApp.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudent db;

        public CreateModel(IStudent _db)
        {
            db = _db;
        }
        [BindProperty]
        public Student Student { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Add(Student);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
