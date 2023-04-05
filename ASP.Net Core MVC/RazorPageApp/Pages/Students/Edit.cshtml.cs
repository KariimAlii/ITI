using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageApp.Models;
using RazorPageApp.Services;

namespace RazorPageApp.Pages.Students
{
    public class EditModel : PageModel
    {
        IStudent db;
        public EditModel(IStudent _db)
        {
            db = _db;
        }
        [BindProperty]
        public Student Student { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id is null) return BadRequest();
            Student std = db.GetById(id.Value);
            if (std == null) return NotFound();
            Student = std;
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Update(Student);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
