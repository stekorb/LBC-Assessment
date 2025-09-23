using VacationManager.Models;

namespace VacationManager.Repositories.Interfaces
{
    public interface IEmployeeRepo
    {
        EmployeeModel RetrieveEmployeeById(Guid employeeId);

        EmployeeModel RetrieveEmployeeByEmail(string email);

        List<EmployeeModel> RetrieveAllEmployees();

        bool CreateEmployee(EmployeeModel model);
    }
}
