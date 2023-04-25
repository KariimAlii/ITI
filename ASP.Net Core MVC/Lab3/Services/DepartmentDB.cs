using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Services
{
    public class DepartmentDB : IDepartment
    {
        ITIContext context; // = new ITIContext();
        public DepartmentDB(ITIContext _context)
        {
            context = _context;
        }
        public List<Department> GetAllDepartments()
        {
            return context.Departments.ToList();
        }
        public void CreateDepartment(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
        }

        public Department GetDepartmentById(int id)
        {
            //Department department = context.Departments.Find(id);
            Department department = context.Departments.FirstOrDefault(d => d.Id == id);
            return department;
        }
        public void UpdateDepartment(Department department)
        {
            Department old = context.Departments.FirstOrDefault(d => d.Id == department.Id);
            if (old != null)
            {
                old.Name = department.Name;
                old.ManagerName = department.ManagerName;
                context.SaveChanges();
            }
        }
        public void DeleteDepartment(int id)
        {
            Department old = context.Departments.FirstOrDefault(d => d.Id == id);
            if (old != null)
            {
                context.Departments.Remove(old);
                context.SaveChanges();
            }
        }

    }

}
