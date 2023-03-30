using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models
{
    public class Course
    {

        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Crs_Id { get; set; }
        public string Crs_Name { get; set; }
        public int LectureHours { get; set; }
        public int LabHours { get; set; }
        public virtual ICollection<StudentCourse> courseStudents { get; set; } = new HashSet<StudentCourse>();
        public virtual ICollection<Department> Departments { get; set; } = new HashSet<Department>();
    }
}
