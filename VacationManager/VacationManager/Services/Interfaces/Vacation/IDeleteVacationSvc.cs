using VacationManager.Common.Responses;

namespace VacationManager.Services.Interfaces.Vacation
{
    public interface IDeleteVacationSvc
    {
        Task<ResponseModel<bool>> Execute(Guid vacationId);
    }
}
