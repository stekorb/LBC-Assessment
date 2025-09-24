using VacationManager.Common.Responses;
using VacationManager.Dto.Vacation;

namespace VacationManager.Services.Interfaces.Vacation
{
    public interface IRegisterNewVacationSvc
    {
        Task<ResponseModel<bool>> Execute(VacationCreateDto dto);
    }
}
