using VacationManager.Common.Responses;
using VacationManager.Dto.Employee;

namespace VacationManager.Services.Interfaces
{
    public interface ICreateEmployeeSvc
    {
        ResponseModel<bool> Execute(EmployeeCreateDto model);
    }
}
