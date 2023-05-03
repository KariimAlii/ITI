using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.DAL
{
    public interface IDepartmentRepo
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department?> GetById(int id);
        Task Add(Department entity);
        void Update(Department entity);
        void Delete(Department entity);
        Task<int> SaveChanges();
        Task<Department?> GetWithTicketsAndDevelopers(int id);
    }
}
