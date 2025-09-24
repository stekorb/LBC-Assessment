using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;

namespace VacationManager.Services.Interfaces.Vacation
{
    public interface IRetrieveAllVacationsSvc
    {
        Task<ResponseModel<List<VacationDto>>> Execute();
    }
}
