using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;

namespace VacationManager.Services.Interfaces.Vacation
{
    public interface IRetrieveEmployeeVacationsSvc
    {
        Task<ResponseModel<List<VacationDto>>> Execute(Guid employeeId);
    }
}
