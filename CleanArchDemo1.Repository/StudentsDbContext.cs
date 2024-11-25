using CleanArchDemo1.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchDemo1.Repository
{
    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext(DbContextOptions<StudentsDbContext> options) :
            base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<StudentModel> Students { get; set; }
    }
}







