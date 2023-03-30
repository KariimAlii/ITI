using Microsoft.EntityFrameworkCore;

namespace Lab3.Models
{
    public class ITIContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=ITIDB;Trusted_Connection=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
