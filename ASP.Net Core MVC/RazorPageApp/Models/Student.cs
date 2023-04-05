using System.ComponentModel.DataAnnotations;

namespace RazorPageApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(10,20)]
        public int Age { get; set; }
    }
}
