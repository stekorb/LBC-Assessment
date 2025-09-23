using Microsoft.EntityFrameworkCore;
using VacationManager.Models;

namespace VacationManager.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<VacationModel> Vacations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
            optionsBuilder.UseSqlite("Data Source=Data/VacationManager.db");
    }
}
