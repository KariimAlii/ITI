using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApi.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}