using StudentApi.BLL;
using StudentApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentApi.Controllers
{
    public class CoursesController : ApiController // Dependent
    {
        private readonly ICourseService _courseService; // Dependency

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public List<Course> Get()
        {
            return _courseService.GetAll();
        }

        [HttpGet]
        public Course Get(int id)
        {
            return _courseService.GetById(id);
        }
    }
}
