using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Context : DbContext
    {
        public Context() : base("Data source = .; Initial catalog = ITI-CodeFirstEF;Integrated Security = True;")
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorksFor> WorksFors { get; set; }
    }
}
