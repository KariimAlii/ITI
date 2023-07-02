using StudentApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace StudentApi.DAL
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDBContext _context;

        public StudentRepository(StudentDBContext context)
        {
            _context = context;
        }

        public List<Student> GetAllStudents()
        {
            // Get cars from dependency
            // Logic
            return _context.Students;
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(c => c.Id == id);
        }
        public Student GetStudentByEmail(string email)
        {
            return _context.Students.FirstOrDefault(c => c.Email == email);
        }

        public Student AddStudent(Student student)
        {
            var id = _context.Students.Count + 1;
            student.Id = id;
            _context.Students.Add(student);
            return student;
        }

    }
}