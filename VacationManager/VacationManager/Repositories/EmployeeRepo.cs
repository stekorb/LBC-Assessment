using VacationManager.Data;
using VacationManager.Models;
using VacationManager.Repositories.Interfaces;

namespace VacationManager.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private AppDbContext _dbContext;

        public EmployeeRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<EmployeeModel> RetrieveAllEmployees()
        {
            var list = _dbContext.Employees.ToList();

            return list;
        }

        public EmployeeModel RetrieveEmployeeById(Guid employeeId)
        {
            var dbObj = _dbContext.Employees.FirstOrDefault(emp => emp.Id == employeeId);
            return dbObj;
        }

        public EmployeeModel RetrieveEmployeeByEmail(string email)
        {
            var dbObj = _dbContext.Employees.FirstOrDefault(emp => emp.Email == email);
            return dbObj;
        }

        public bool CreateEmployee(EmployeeModel model)
        {
            _dbContext.Employees.Add(model);
            _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
