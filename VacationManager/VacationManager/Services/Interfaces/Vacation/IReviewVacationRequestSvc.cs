using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;

namespace VacationManager.Services.Interfaces.Vacation
{
    public interface IReviewVacationRequestSvc
    {
        Task<ResponseModel<bool>> Execute(VacationReviewDto dto);
    }
}
