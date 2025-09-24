using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;

namespace VacationManager.Services.Interfaces.Vacation
{
    public interface IUpdateVacationRequestSvc
    {
        Task<ResponseModel<bool>> Execute(VacationDto dto);
    }
}
