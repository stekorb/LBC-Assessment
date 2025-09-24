using VacationManager.Common.Responses;
using VacationManager.Dto.Employee;

namespace VacationManager.Services.Interfaces.Employee
{
    public interface ICreateEmployeeSvc
    {
        Task<ResponseModel<bool>> Execute(EmployeeCreateDto model);
    }
}
