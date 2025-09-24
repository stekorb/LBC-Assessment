using VacationManager.Common.Responses;
using VacationManager.Dto.Employee;

namespace VacationManager.Services.Interfaces.Employee
{
    public interface IRetrieveAllEmployeesSvc
    {
        Task<ResponseModel<List<EmployeeDto>>> Execute();
    }
}
