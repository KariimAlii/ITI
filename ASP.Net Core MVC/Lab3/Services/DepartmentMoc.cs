using Lab3.Models;

namespace Lab3.Services
{
    public class DepartmentMoc : IDepartment
    {
        static List<Department> departments = new List<Department>()
        {
            new Department() { Id = 1 , Name = "PWD" , ManagerName = "Mohamed Zayat"},
            new Department() { Id = 2 , Name = "Open Source" , ManagerName = "Sameh Mohamed"},
            new Department() { Id = 3 , Name = "Cyber Security" , ManagerName = "Fares Ashraf"},
        };
        public List<Department> GetAllDepartments()
        {
            return departments;
        }
        public void CreateDepartment(Department department)
        {
            departments.Add(department);
        }

        public Department GetDepartmentById(int id)
        {
            Department department = departments.FirstOrDefault(d => d.Id == id);
            return department;
        }
        public void UpdateDepartment(Department department)
        {
            Department old = departments.FirstOrDefault(d => d.Id == department.Id);
            if (old != null)
            {
                old.Name = department.Name;
                old.ManagerName = department.ManagerName;
            }
        }
        public void DeleteDepartment(int id)
        {
            Department old = departments.FirstOrDefault(d => d.Id == id);
            if (old != null) departments.Remove(old);
        }
    }
}
