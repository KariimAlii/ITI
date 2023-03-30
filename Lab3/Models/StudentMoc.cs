using Microsoft.AspNetCore.Http.HttpResults;

namespace Lab3.Models
{
    public class StudentMoc
    {
        //List<Student> students = new List<Student>(); //===> No Data
        static List<Student> students = new List<Student>()
        {
            new Student() { Id = 1, Name = "Karim", Grade = 77 ,Email = "k@gmail.com"},
            new Student() { Id = 2, Name = "Mohamed", Grade = 88, Email="i@hotmail.com" },
            new Student() { Id = 3, Name = "Ahmed", Grade = 99 , Email="n@yahoo.com" },
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
        public Student isExists(string email)
        {
            return students.FirstOrDefault(s => s.Email == email);
        }
    }
}
