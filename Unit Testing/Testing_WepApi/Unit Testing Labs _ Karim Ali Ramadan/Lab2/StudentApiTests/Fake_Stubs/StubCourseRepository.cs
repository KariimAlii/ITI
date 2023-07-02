using StudentApi.DAL;
using StudentApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApiTests.Fake_Stubs
{
    public class StubCourseRepository : ICourseRepository
    {
        private readonly FakeInMemoryContext _context;

        public StubCourseRepository(FakeInMemoryContext context)
        {
            _context = context;
        }

        public List<Course> GetAllCourses()
        {
            return _context.Courses;
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.Id == id);
        }
    }
}
