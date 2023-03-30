using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Services
{
    public class StudentDB : IStudent
    {
        ITIContext context;
        public StudentDB(ITIContext _context)
        {
            context = _context;
        }
        public List<Student> GetAllStudents()
        {
            return context.Students.Include(s => s.Department).ToList();
        }
        public void AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }
        public Student GetStudentById(int id)
        {
            return context.Students.FirstOrDefault(s => s.Id == id);
        }
        public void UpdateStudent(Student student)
        {
            Student old = context.Students.FirstOrDefault(s => s.Id == student.Id);
            if (old != null)
            {
                old.Name = student.Name;
                old.Grade = student.Grade;
                context.SaveChanges();
            }
        }
        public void DeleteStudent(int id)
        {
            Student old = context.Students.FirstOrDefault(s => s.Id == id);
            context.Students.Remove(old);
            context.SaveChanges();
        }
        public Student isExists(string email)
        {
            return context.Students.FirstOrDefault(s => s.Email == email);
        }
    }
}
