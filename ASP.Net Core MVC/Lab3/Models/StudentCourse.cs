using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models
{
    public class StudentCourse
    {
        [ForeignKey("Course")]
        public int Course_Id { get; set; }
        [ForeignKey("Student")]
        public int Student_Id { get; set; }
        public int Grade { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
