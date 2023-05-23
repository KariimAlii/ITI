
using StudentApi.DAL;
using StudentApi.Entities;
using StudentApi.Models;
using StudentApi.Payment;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Unity;

namespace StudentApi.BLL
{
    public class StudentService : IStudentService // Dependent
    {
        private readonly IStudentRepository _studentRepository; // Dependency
        private readonly ICourseRepository _courseRepository; // Dependency
        //private readonly IUnityContainer _unityContainer;
        private readonly IPaymentService _paymentService; // Dependency

        public StudentService(
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IPaymentService paymentService
            )
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _paymentService = paymentService;
            //_unityContainer = unityContainer;
        }

        public string Register(RegistrationInput input)
        {
            if (input == null)
                return "";
            if (string.IsNullOrEmpty(input.Name))
                return "Empty name";
            if (string.IsNullOrEmpty(input.Email))
                return "Empty email";
            if (string.IsNullOrEmpty(input.Password))
                return "Empty password";
            if (!IsValid(input.Email))
                return "invalid email";

            var student = new Student()
            {
                Name = input.Name,
                Email = input.Email,
                Password = input.Password
            };
            _studentRepository.AddStudent(student);
            return "Successful registration";
        }

        private bool IsValid(string emailaddress)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(emailaddress, regex, RegexOptions.IgnoreCase);
        }

        public string SignIn(SignInInput input)
        {
            if (string.IsNullOrEmpty(input.Email))
                return "Empty email";
            if (string.IsNullOrEmpty(input.Password))
                return "Empty password";

            var student = _studentRepository.GetStudentByEmail(input.Email);
            if (student == null)
                return "User not found";

            if (student.Password != input.Password)
                return "Invalid password";

            return "Successful signin";
        }

        public string BuyCourse(BuyCourseInput input)
        {
            try
            {
                var student = _studentRepository.GetStudentById(input.StudentId);
                if (student == null)
                    return "Student not found";

                var course = _courseRepository.GetCourseById(input.CourseId);
                if (course == null)
                    return "Course not found";

                if (student.Courses.Any(c => c.Id == course.Id))
                    return "Course is already bought";

                if (input.AmountPaid <= 0)
                    return "Amount should be positive";

                //var paymentService = GetPaymentMethod(input.Method);
                var paymentResult = _paymentService.Pay(input.AmountPaid);
                return $"Successful \r\nCourse {course.Name} is bought by {student.Name} with payment result {paymentResult}";
            }
            catch (Exception)
            {
                return "Sorry! Error has occured";
            }
        }

        //private IPaymentService GetPaymentMethod(PaymentMethod method)
        //{
        //    if (method == PaymentMethod.Cash)
        //        return _unityContainer.Resolve<IPaymentService>("Cash");
        //    else if (method == PaymentMethod.CreditCard)
        //        return _unityContainer.Resolve<IPaymentService>("Card");
        //    throw new System.NotImplementedException();
        //}
    }
}