using Lab3.Models;

namespace Lab3.Services
{
    public interface IStudent
    {
        public List<Student> GetAllStudents();
        public void AddStudent(Student student);
        public Student GetStudentById(int id);
        public void UpdateStudent(Student student);
        public void DeleteStudent(int id);
        public Student isExists(string email);
    }
}
