using Microsoft.EntityFrameworkCore;

namespace test_project.Models
{
    public class StudentsAPIDbContext : DbContext
    {
        public StudentsAPIDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Student> Students
        {
            get;
            set;
        }
    }
}
