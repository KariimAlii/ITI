using StudentApi.Models;

namespace StudentApi.BLL
{
    public interface IStudentService
    {
        string BuyCourse(BuyCourseInput input);
        string Register(RegistrationInput input);
        string SignIn(SignInInput input);
    }
}