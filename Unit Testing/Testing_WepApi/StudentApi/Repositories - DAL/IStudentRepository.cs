using StudentApi.Entities;
using System.Collections.Generic;

namespace StudentApi.DAL
{
    public interface IStudentRepository
    {
        Student AddStudent(Student student);
        List<Student> GetAllStudents();
        Student GetStudentByEmail(string email);
        Student GetStudentById(int id);
    }
}