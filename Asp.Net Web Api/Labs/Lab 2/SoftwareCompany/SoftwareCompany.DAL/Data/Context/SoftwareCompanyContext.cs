using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.DAL
{
    public class SoftwareCompanyContext : DbContext
    {
        #region Only Getter
        //public DbSet<Department> Departments
        //{
        //    get { return Set<Department>(); }
        //}
        #endregion
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Developer> Developers => Set<Developer>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public SoftwareCompanyContext(DbContextOptions<SoftwareCompanyContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seeding Data

            List<Department> departments = new List<Department>
            {
                new Department
                {
                    Id = 1,
                    Name = "Business"
                },
                new Department
                {
                    Id = 2,
                    Name = "Education"
                },
                new Department
                {
                    Id = 3,
                    Name = "Hospitals"
                }
            };
            List<Developer> developers = new List<Developer>
            {
                new Developer
                {
                    Id = 1,
                    Name = "Karim Ali",
                    Salary = 24000
                },
                new Developer
                {
                    Id = 2,
                    Name = "Rana Youssef",
                    Salary = 30000
                },
                new Developer
                {
                    Id = 3,
                    Name = "Mohamed Moustafa",
                    Salary = 21000
                }
            };
            List<Ticket> tickets = new List<Ticket>
            {
                new Ticket
                {
                    Id = 1,
                    Description = "Fix Code Issues",
                    Title = "Bug Fixing",
                    DepartmentId = 2
                },
                new Ticket
                {
                    Id = 2,
                    Description = "Add Animations on Landing Page",
                    Title = "Landing Page",
                    DepartmentId = 1
                },
                new Ticket
                {
                    Id = 3,
                    Description = "Update Connection String to DB Server",
                    Title = "DB Server",
                    DepartmentId = 3
                }
            };

            modelBuilder.Entity<Department>().HasData(departments);
            modelBuilder.Entity<Developer>().HasData(developers);
            modelBuilder.Entity<Ticket>().HasData(tickets);

            #endregion

            #region Configuring One to Many Relationship (1 Department with Many Tickets)

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Department)
                .WithMany(d => d.Tickets)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Bad idea
            //1. You don't have access to the Configuration.
            //2. You dont' have access to the current environment app.Environment.
            //3. You can't configure the database connection string based on the eenvironment
            //optionsBuilder.UseSqlServer("YOUR_CONNECTION_STRING");
        }
    }
}

#region Useful Tutorials
// Initializing DBSet ==> https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/dbsets
// Data Seeding ==> https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
// Configuting One to Many Relationship ===> https://www.entityframeworktutorial.net/efcore/one-to-many-conventions-entity-framework-core.aspx
// Configuting Relationships ===> https://learn.microsoft.com/en-us/ef/core/modeling/relationships
// Referential Integrity Constrain ==> https://www.learnentityframeworkcore.com/configuration/one-to-many-relationship-configuration
// OnDelete ==> https://riptutorial.com/ef-core-advanced-topics/learn/100014/cascade-delete
#endregion
