using StudentApi.DAL;
using StudentApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApiTests.Fake_Stubs
{
    public class StubStudentRepository : IStudentRepository
    {
        private readonly FakeInMemoryContext _context;

        public StubStudentRepository(FakeInMemoryContext context)
        {
            _context = context;
        }

        public List<Student> GetAllStudents()
        {
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
