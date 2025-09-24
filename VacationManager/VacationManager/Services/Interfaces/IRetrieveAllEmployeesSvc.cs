using VacationManager.Common.Responses;
using VacationManager.Dto.Employee;

namespace VacationManager.Services.Interfaces
{
    public interface IRetrieveAllEmployeesSvc
    {
        Task<ResponseModel<List<EmployeeDto>>> Execute();
    }
}
