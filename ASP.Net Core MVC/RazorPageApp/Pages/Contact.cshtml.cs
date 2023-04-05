using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace RazorPageApp.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty()]
        public int Id { get; set; }
        [BindProperty]
        public string Name { get; set; }
        public void OnGet()
        {
            Id = 10;
            Name = "Ali";
        }
        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
//public void OnPost(int id, string name)
//{
//    Id = id;
//    Name = name;
//}