using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;
using VacationManager.Models;

namespace VacationManager.Services.Interfaces.Vacation
{
    public interface IRetrieveVacationsAwaitingReviewSvc
    {
        Task<ResponseModel<List<VacationDto>>> Execute(Guid managerId);
    }
}
