using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        #region Fields
        private readonly SoftwareCompanyContext context;

        public GenericRepository(SoftwareCompanyContext _context)
        {
            context = _context;
        }
        #endregion

        #region Methods
        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().AsNoTracking(); // ReadOnly
        }

        public TEntity? GetById(int id)
        {
            return context.Set<TEntity>().Find(id); // You cannot use .AsNoTracking()
            //return context.Set<TEntity>().FirstOrDefault(id).AsNoTracking(); // You can use .AsNoTracking()
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            // Only in case you use .AsNoTracking() ====> context.Update(entity);
        }
        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }
        public int SaveChanges()
        {
            return context.SaveChanges();
        }
        #endregion
    }
}
