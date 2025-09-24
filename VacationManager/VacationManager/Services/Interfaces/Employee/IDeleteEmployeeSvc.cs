using VacationManager.Common.Responses;

namespace VacationManager.Services.Interfaces.Employee
{
    public interface IDeleteEmployeeSvc
    {
        Task<ResponseModel<bool>> Execute(Guid employeeId);
    }
}
