using StudentApi.Entities;
using StudentApi.DAL;
using System.Collections.Generic;

namespace StudentApi.BLL
{
    public class CourseService : ICourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public List<Course> GetAll()
        {
            return _courseRepository.GetAllCourses();
        }

        public Course GetById(int id)
        {
            return _courseRepository.GetCourseById(id);
        }
    }
}