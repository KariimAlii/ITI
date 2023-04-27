using SoftwareCompany.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.BL
{
    public class DepartmentManager : IDepartmentManager
    {

        #region Fields & Constructor
        private readonly IGenericRepository<Department> departmentRepo;

        public DepartmentManager(IGenericRepository<Department> _departmentRepo)
        {
            departmentRepo = _departmentRepo;
        }
        #endregion

        #region Methods


        public IEnumerable<DepartmentReadDto> GetAll()
        {
            var departmentsFromDB = departmentRepo.GetAll();
            return departmentsFromDB.Select(d => new DepartmentReadDto
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();
        }
        public DepartmentReadDto? GetById(int id)
        {
            var departmentFromDB = departmentRepo.GetById(id);
            if (departmentFromDB == null)
                return null;
            return new DepartmentReadDto
            {
                Id = departmentFromDB.Id,
                Name = departmentFromDB.Name
            };
        }
        public int Add(DepartmentAddDto departmentDto)
        {
            var newDepartment = new Department
            {
                Name = departmentDto.Name
            };
            departmentRepo.Add(newDepartment);
            // newDepartment.Id = default
            departmentRepo.SaveChanges(); //====> returns the object added with its {Id} set by database provider
            // newDepartment.Id = 157
            return newDepartment.Id;
        }
        public bool Update(DepartmentUpdateDto departmentDto)
        {
            var departmentFromDB = departmentRepo.GetById(departmentDto.Id);
            if (departmentFromDB == null)
                return false;
            departmentFromDB.Name = departmentDto.Name;
            departmentRepo.Update(departmentFromDB);
            departmentRepo.SaveChanges();
            return true;
        }
        public void Delete(int id)
        {
            var departmentFromDB = departmentRepo.GetById(id);
            if (departmentFromDB == null)
                return;
            departmentRepo.Delete(departmentFromDB);
            departmentRepo.SaveChanges();
        }
        #endregion
    }
}
