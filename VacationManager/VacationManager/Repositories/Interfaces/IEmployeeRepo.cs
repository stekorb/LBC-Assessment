using VacationManager.Models;

namespace VacationManager.Repositories.Interfaces
{
    public interface IEmployeeRepo
    {
        Task<EmployeeModel> RetrieveEmployeeById(Guid employeeId);

        Task<EmployeeModel> RetrieveEmployeeByEmail(string email);

        Task<List<EmployeeModel>> RetrieveAllEmployees();

        Task<bool> CreateEmployee(EmployeeModel model);

        Task<bool> UpdateEmployee(EmployeeModel model);

        Task<bool> DeleteEmployee(Guid employeeId);

        Task<bool> IsEmployeeAdminOrManager(Guid employeeId);

        Task<List<EmployeeModel>> RetrieveManagedEmployees(Guid managerId);
    }
}
