using VacationManager.Common.Responses;
using VacationManager.Dto.Employee;

namespace VacationManager.Services.Interfaces
{
    public interface IRetrieveAllEmployeesSvc
    {
        ResponseModel<List<EmployeeDto>> Execute();
    }
}
