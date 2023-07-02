using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentApi.BLL;
using StudentApi.DAL;
using StudentApi.Entities;
using StudentApi.Models;
using StudentApi.Payment;
using StudentApiTests.Fake_Stubs;
using System;
using Moq;

namespace StudentApiTests
{
    [TestClass]
    public class StudentServiceTests
    {
        private static Mock<IStudentRepository> _mockStudentRepository = new Mock<IStudentRepository>();
        private static Mock<ICourseRepository> _mockCourseRepository = new Mock<ICourseRepository>();
        private static Mock<IPaymentService> _mockPaymentService = new Mock<IPaymentService>();

        private static StudentService _studentService;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _mockStudentRepository = new Mock<IStudentRepository>();
            _mockCourseRepository = new Mock<ICourseRepository>();
            _mockPaymentService = new Mock<IPaymentService>();
            _studentService = new StudentService(
                _mockStudentRepository.Object,
                _mockCourseRepository.Object,
                _mockPaymentService.Object
                );
        }

        #region Tightly coupled
        [TestMethod]
        public void BuyCourse_AlreadyBoughtCourse_PrintCourseIsAlreadyBought_TightlyCoupled()
        {
            // Arrange
            var studentService = new StudentService(
                new StudentRepository(new StudentApi.Entities.StudentDBContext()),
                new CourseRepository(new StudentApi.Entities.StudentDBContext()),
                new CashService()
                );
            var input = new BuyCourseInput()
            {
                AmountPaid = 1,
                StudentId = 1,
                CourseId = 1
            };

            // Act
            var result = studentService.BuyCourse(input);


            // Assert
            StringAssert.Matches(result, new System.Text.RegularExpressions.Regex("^Course is already bought$"));
        }

        // Depend on direct implemetation of dependencies
        // Depend on a DB, which saves changes in state

        [TestMethod]
        public void BuyCourse_StudentBuyNewCourse_PrintSuccessful()
        {
            // Arrange
            var studentService = new StudentService(
                new StudentRepository(new StudentApi.Entities.StudentDBContext()),
                new CourseRepository(new StudentApi.Entities.StudentDBContext()),
                new CashService()
                );
            var input = new BuyCourseInput()
            {
                AmountPaid = 1,
                StudentId = 3,
                CourseId = 1
            };

            // Act
            var result = studentService.BuyCourse(input);


            // Assert
            StringAssert.Contains(result, "Successful");
        }
        #endregion

        #region Fake_Stubs
        [TestMethod]
        public void BuyCourse_AlreadyBoughtCourse_PrintCourseIsAlreadyBought_Fake()
        {
            // Arrange
            var studentService = new StudentService(
                new StubStudentRepository(new FakeInMemoryContext()),
                new StubCourseRepository(new FakeInMemoryContext()),
                new StubPaymentService()
                );
            var input = new BuyCourseInput()
            {
                AmountPaid = 1,
                StudentId = 2,
                CourseId = 2
            };

            // Act
            var result = studentService.BuyCourse(input);


            // Assert
            StringAssert.Matches(result, new System.Text.RegularExpressions.Regex("^Course is already bought$"));
        }
        // Rewrite code

        [TestMethod]
        public void BuyCourse_ExceptionOccur_PrintErrorHasOccured_Fake()
        {
            // Arrange
            var studentService = new StudentService(
                new StubStudentRepository(new FakeInMemoryContext()),
                new StubCourseRepository(new FakeInMemoryContext()),
                new StubExceptionPaymentService()
                );
            var input = new BuyCourseInput()
            {
                AmountPaid = 1,
                StudentId = 1,
                CourseId = 2
            };

            // Act
            var result = studentService.BuyCourse(input);


            // Assert
            StringAssert.Matches(result, new System.Text.RegularExpressions.Regex("^Sorry! Error has occured$"));
        }
        #endregion

        #region Mocking
        [TestMethod]
        public void BuyCourse_AlreadyBoughtCourse_PrintCourseIsAlreadyBought_MOQ()
        {
            // Arrange
            var input = new BuyCourseInput()
            {
                AmountPaid = 1,
                StudentId = 2,
                CourseId = 2
            };
            var course = new Course();
            _mockCourseRepository.Setup(m => m.GetCourseById(input.CourseId)).Returns(course);
            var student = new Student();
            student.Courses.Add(course);
            _mockStudentRepository.Setup(m => m.GetStudentById(input.StudentId)).Returns(student);


            // Act
            var result = _studentService.BuyCourse(input);


            // Assert
            StringAssert.Matches(result, new System.Text.RegularExpressions.Regex("^Course is already bought$"));
        }
        [TestMethod]
        public void BuyCourse_ValidInput_PrintSuccessful()
        {
            // Arrange
            var input = new BuyCourseInput()
            {
                AmountPaid = 1,
                StudentId = 2,
                CourseId = 2
            };
            var course = new Course();
            _mockCourseRepository.Setup(m => m.GetCourseById(It.IsAny<int>())).Returns(course);
            var student = new Student();
            _mockStudentRepository.Setup(m => m.GetStudentById(input.StudentId)).Returns(student);
            _mockPaymentService.Setup(m => m.Pay(input.AmountPaid)).Returns("paid through wallet");


            // Act
            var result = _studentService.BuyCourse(input);


            // Assert
            StringAssert.Contains(result, "paid through wallet");
        }
        #endregion
    }
}
