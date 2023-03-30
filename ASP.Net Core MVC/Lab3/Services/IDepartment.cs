using Lab3.Models;

namespace Lab3.Services
{
    public interface IDepartment
    {
        public List<Department> GetAllDepartments();
        public void CreateDepartment(Department department);
        public Department GetDepartmentById(int id);
        public void UpdateDepartment(Department department);
        public void DeleteDepartment(int id);
    }
}
