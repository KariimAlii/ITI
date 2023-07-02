using StudentApi.Entities;
using System.Collections.Generic;

namespace StudentApi.DAL
{
    public interface ICourseRepository
    {
        List<Course> GetAllCourses();
        Course GetCourseById(int id);
    }
}