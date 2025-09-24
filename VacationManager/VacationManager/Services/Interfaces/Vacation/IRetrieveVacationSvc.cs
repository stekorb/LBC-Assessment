using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;

namespace VacationManager.Services.Interfaces.Vacation
{
    public interface IRetrieveVacationSvc
    {
        Task<ResponseModel<VacationDto>> Execute(Guid vacationId);
    }
}
