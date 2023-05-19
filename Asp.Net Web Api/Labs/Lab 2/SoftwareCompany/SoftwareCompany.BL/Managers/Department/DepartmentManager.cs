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
        private readonly IDepartmentRepo departmentRepo;

        public DepartmentManager(IDepartmentRepo _departmentRepo)
        {
            departmentRepo = _departmentRepo;
        }
        #endregion

        #region Methods


        public async Task<IEnumerable<DepartmentReadDto>> GetAll()
        {
            var departmentsFromDB = await departmentRepo.GetAll();
            return departmentsFromDB.Select(d => new DepartmentReadDto
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();
        }
        public async Task<DepartmentReadDto?> GetById(int id)
        {
            var departmentFromDB = await departmentRepo.GetById(id);
            if (departmentFromDB == null)
                return null;
            return new DepartmentReadDto
            {
                Id = departmentFromDB.Id,
                Name = departmentFromDB.Name
            };
        }
        public async Task<int> Add(DepartmentAddDto departmentDto)
        {
            var newDepartment = new Department
            {
                Name = departmentDto.Name
            };
            await departmentRepo.Add(newDepartment);
            // newDepartment.Id = default
            await departmentRepo.SaveChanges(); //====> returns the object added with its {Id} set by database provider
            // newDepartment.Id = 157
            return newDepartment.Id;
        }
        public async Task<bool> Update(DepartmentUpdateDto departmentDto)
        {
            var departmentFromDB = await departmentRepo.GetById(departmentDto.Id);
            if (departmentFromDB == null)
                return false;
            departmentFromDB.Name = departmentDto.Name;
            departmentRepo.Update(departmentFromDB);
            await departmentRepo.SaveChanges();
            return true;
        }
        public async Task Delete(int id)
        {
            var departmentFromDB = await departmentRepo.GetById(id);
            if (departmentFromDB == null)
                return;
            departmentRepo.Delete(departmentFromDB);
            await departmentRepo.SaveChanges();
        }
        public async Task<DepartmentReadDetailsDto?> GetDetails(int id)
        {
            Department? departmentFromDB = await departmentRepo.GetWithTicketsAndDevelopers(id);
            if (departmentFromDB is null)
                return null;
            return new DepartmentReadDetailsDto
            {
                Id = departmentFromDB.Id,
                Name = departmentFromDB.Name,
                // List<Ticket> -----mapping----> List<TicketChildReadDto>
                Tickets = departmentFromDB.Tickets
                    .Select(t => new TicketChildReadDto
                    {
                        Id = t.Id,
                        Description = t.Description,
                        DevelopersCount = t.Developers.Count
                    })
                    .ToList()
            };
        }
        #endregion
    }
}
