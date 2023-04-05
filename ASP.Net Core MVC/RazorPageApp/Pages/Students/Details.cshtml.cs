using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageApp.Models;
using RazorPageApp.Services;

namespace RazorPageApp.Pages.Students
{
    public class DetailsModel : PageModel
    {
        IStudent db;
        public DetailsModel(IStudent _db)
        {
            db = _db;
        }
        [BindProperty]
        public Student Student { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id is null) return BadRequest();


            var std = db.GetById(id.Value);
            if (std == null) return NotFound();

            Student = std;
            return Page();
        }

    }
}
