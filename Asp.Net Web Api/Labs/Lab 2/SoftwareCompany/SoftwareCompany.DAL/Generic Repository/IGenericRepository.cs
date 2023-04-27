using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.DAL
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(int id);
        void Add (TEntity entity);
        void Update (TEntity entity);
        void Delete (TEntity entity);
        int SaveChanges();
    }
}
