using VacationManager.Common.Responses;
using VacationManager.Dto.Employee;

namespace VacationManager.Services.Interfaces.Employee
{
    public interface IUpdateEmployeeSvc
    {
        Task<ResponseModel<bool>> Execute(EmployeeDto dto);
    }
}
