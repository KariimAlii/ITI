using Microsoft.EntityFrameworkCore;

namespace Lab3.Models
{
    public class ITIContext : DbContext
    {
        // Dependency Injection Constructor
        public ITIContext (DbContextOptions options) : base(options) { }
        // Default Constructor
        public ITIContext() { }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=ITIDB;Trusted_Connection=true;");
            base.OnConfiguring(optionsBuilder);
        }
        // Fluent Api ==> https://www.learnentityframeworkcore.com/configuration/fluent-api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(c => new { c.Student_Id, c.Course_Id });
            base.OnModelCreating(modelBuilder);
        }
    }
}
