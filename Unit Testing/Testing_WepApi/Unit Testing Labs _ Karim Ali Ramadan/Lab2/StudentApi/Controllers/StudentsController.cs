using StudentApi.BLL;
using StudentApi.Models;
using System.Web.Http;

namespace StudentApi.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public string Register([FromBody] RegistrationInput input)
        {
            return _studentService.Register(input);
        }

        [HttpPost]
        public string SignIn([FromBody] SignInInput input)
        {
            return _studentService.SignIn(input);
        }

        [HttpPost]
        public string BuyCourse([FromBody] BuyCourseInput input)
        {
            return _studentService.BuyCourse(input);
        }

    }
}
