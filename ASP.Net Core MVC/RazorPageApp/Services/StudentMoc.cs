using RazorPageApp.Models;

namespace RazorPageApp.Services
{
    public class StudentMoc : IStudent
    {
        List<Student> students = new List<Student>()
        {
            new Student() {Id = 1 , Name = "Karim Ali" , Age = 26},
            new Student() {Id = 2 , Name = "Mohamed Moustafa" , Age = 23},
            new Student() {Id = 3 , Name = "Ahmed Hassanein" , Age = 23},
            new Student() {Id = 4 , Name = "Mohamed Ahmed" , Age = 25},
            new Student() {Id = 5 , Name = "Hesham" , Age = 25},
        };

        public Student Add(Student student)
        {
            students.Add(student);
            return student;
        }

        public void DeleteById(int id)
        {
            Student std = GetById(id);
            students.Remove(std);
        }

        public List<Student> GetAll()
        {
            return students;
        }

        public Student GetById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public Student Update(Student student)
        {
            Student oldStd = GetById(student.Id);
            oldStd.Name = student.Name;
            oldStd.Age = student.Age;
            return oldStd;
        }
    }
}
