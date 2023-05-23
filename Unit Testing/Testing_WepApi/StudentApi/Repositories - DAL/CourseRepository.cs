using StudentApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace StudentApi.DAL
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentDBContext _context;

        public CourseRepository(StudentDBContext context)
        {
            _context = context;
        }

        public List<Course> GetAllCourses()
        {
            // Get cars from dependency
            // Logic
            return _context.Courses;
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.Id == id);
        }
    }
}