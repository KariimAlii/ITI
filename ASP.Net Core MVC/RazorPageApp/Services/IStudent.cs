using RazorPageApp.Models;

namespace RazorPageApp.Services
{
    public interface IStudent
    {
        public List<Student> GetAll();
        public Student GetById(int id);
        public Student Add(Student student);
        public Student Update(Student student);
        public void DeleteById(int id);
    }
}
