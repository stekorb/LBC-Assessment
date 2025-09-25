using Microsoft.EntityFrameworkCore;
using VacationManager.Common.Enums;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string hashedPassword = "AQAAAAIAAYagAAAAECLXxn5VxPYjvCLc6EUyvHJGS5wRYq3KxzCPP9t03tXF5xnUY9Wv8j4B7fpnEXjPKA==";
            Guid id = new Guid("2f797cb5-157a-4569-91d8-e9d5164048e0");

            modelBuilder.Entity<EmployeeModel>().HasData(new EmployeeModel
            {
                Id = id,
                Email = "admin@workflow.com",
                Name = "Administrator",
                Password = hashedPassword,
                Role = RoleEnum.Administrator,
                ManagerId = null
            });
        }
    }
}
