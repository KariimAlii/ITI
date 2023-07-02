using StudentApi.Entities;
using System.Collections.Generic;

namespace StudentApi.BLL
{
    public interface ICourseService
    {
        List<Course> GetAll();
        Course GetById(int id);
    }
}