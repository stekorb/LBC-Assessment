using Microsoft.EntityFrameworkCore;
using VacationManager.Common.Enums;
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

        public async Task<List<EmployeeModel>> RetrieveAllEmployees()
        {
            var list = await _dbContext.Employees.ToListAsync();

            return list;
        }

        public async Task<EmployeeModel> RetrieveEmployeeById(Guid employeeId)
        {
            var dbObj = await _dbContext.Employees.FirstOrDefaultAsync(emp => emp.Id == employeeId);
            return dbObj;
        }

        public async Task<EmployeeModel> RetrieveEmployeeByEmail(string email)
        {
            var dbObj = await _dbContext.Employees.FirstOrDefaultAsync(emp => emp.Email == email);
            return dbObj;
        }

        public async Task<bool> CreateEmployee(EmployeeModel model)
        {
            _dbContext.Employees.Add(model);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateEmployee(EmployeeModel model)
        {
            var dbObj = await _dbContext.Employees.FirstOrDefaultAsync(emp => emp.Id == model.Id);

            if(dbObj != null)
            {
                dbObj.Name = model.Name;
                dbObj.Email = model.Email;
                dbObj.Role = model.Role;
                dbObj.ManagerId = model.ManagerId;

                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> DeleteEmployee(Guid employeeId)
        {
            var dbObj = await _dbContext.Employees.FirstOrDefaultAsync(emp => emp.Id == employeeId);

            if(dbObj != null)
            {
                _dbContext.Employees.Remove(dbObj);
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> IsEmployeeAdminOrManager(Guid employeeId)
        {
            var dbObj = await _dbContext.Employees.FirstOrDefaultAsync(emp => emp.Id == employeeId);
            if(dbObj != null)
            {
                return dbObj.Role == RoleEnum.Manager || dbObj.Role == RoleEnum.Administrator;
            }

            return false;
        }

        public async Task<List<EmployeeModel>> RetrieveManagedEmployees(Guid managerId)
        {
            return await _dbContext.Employees.Where(emp => emp.ManagerId == managerId).ToListAsync();
        }
    }
}
