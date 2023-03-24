using Microsoft.AspNetCore.Http.HttpResults;

namespace Lab3.Models
{
    public class StudentMoc
    {
        //List<Student> students = new List<Student>(); //===> No Data
        static List<Student> students = new List<Student>()
        {
            new Student() { Id = 1, Name = "Karim", Grade = 77 },
            new Student() { Id = 2, Name = "Mohamed", Grade = 88 },
            new Student() { Id = 3, Name = "Ahmed", Grade = 99 },
        };
        public List<Student> GetAllStudents()
        {
            return students;
        }
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }
        public void UpdateStudent(Student student)
        {
            Student old = students.FirstOrDefault(s => s.Id == student.Id);
            if (old != null)
            {
                old.Name = student.Name;
                old.Grade = student.Grade;
            }
        }
        public void DeleteStudent(int id)
        {
            Student old = students.FirstOrDefault(s => s.Id == id);
            students.Remove(old);
        }
    }
}
