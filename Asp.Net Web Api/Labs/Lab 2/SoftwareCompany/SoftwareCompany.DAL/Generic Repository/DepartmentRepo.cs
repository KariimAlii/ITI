using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.DAL
{
    public class DepartmentRepo : IDepartmentRepo
    {
        #region Fields
        private readonly SoftwareCompanyContext context;

        public DepartmentRepo(SoftwareCompanyContext _context)
        {
            context = _context;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Department>> GetAll()
        {
            return await context.Set<Department>().AsNoTracking().ToListAsync(); // ReadOnly
        }

        public async Task<Department?> GetById(int id)
        {
            return await context.Set<Department>().FindAsync(id); // You cannot use .AsNoTracking()
            //return context.Set<Department>().FirstOrDefault(id).AsNoTracking(); // You can use .AsNoTracking()
        }

        public async Task Add(Department entity)
        {
            await context.Set<Department>().AddAsync(entity);
        }

        public void Update(Department entity)
        {
            // Only in case you use .AsNoTracking() ====> context.Update(entity);
        }
        public void Delete(Department entity)
        {
            context.Set<Department>().Remove(entity);
        }
        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }
        public async Task<Department?> GetWithTicketsAndDevelopers(int id)
        {
            return await context.Set<Department>()
                .Include(d => d.Tickets)
                //.Include(d => d.Tickets.Where(t => t.Id > 10)
                    .ThenInclude(t => t.Developers)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
        #endregion
    }
}
